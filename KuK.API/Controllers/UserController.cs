using KuK.Service;
using KuK.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KuK.API.Controllers
{
    [EnableCors("*","*","*")] //any origin is allowed but restrict to frontend app
    public class UserController : ApiController
    {

        private UserService _userService = new UserService {}; //this is service and other is in services ?? vs is weird
        private LogService _logService = new LogService { };

        [HttpGet]
        public IHttpActionResult GetUsers(int userID)
        {
            try
            {
                var list = _userService.GetUsers();
                if(list.Count == 0)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch(Exception ex)//catch any exception this is an antipatern any exxception shold be threated deiferent
            {
                var text = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(text, userID);
                return InternalServerError(); //user shuld not know what is wrong, admin should only know
            }
        }


        [HttpPost]
        public IHttpActionResult AddUser([FromBody] string firstName, string lastName, string password, string emailAddress)
        {
            try
            {
                password = GetHashString(password);
                _userService.AddUser(firstName, lastName, password, emailAddress);
                return Ok();
            }
            catch(Exception ex)
            {
                var text = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(text, 0);
                return InternalServerError(); //user shuld not know what is wrong, admin should only know
            }
        }

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

    }
}
