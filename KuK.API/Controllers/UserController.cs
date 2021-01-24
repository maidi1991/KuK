using KuK.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KuK.API.Controllers
{
    [EnableCors("*","*","*")] //any origin is allowed but restrict to frontend app
    public class UserController : ApiController
    {

        private UserService _userService = new UserService {};

        [HttpGet]
        public IHttpActionResult GetUsers()
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
            catch(Exception ex)//catch any exxception this is an antipatern any exxception shold be threated deiferent
            {
                //To DO Log Exception
                return InternalServerError();
            }
        }


        [HttpPost]
        public IHttpActionResult AddUser([FromBody] string firstName, string lastName, string password, string emailAddress)
        {
            try
            {
                _userService.AddUser(firstName, lastName, password, emailAddress);
                return Ok();
            }
            catch(Exception ex)
            {
                //TO DO log expeption ex
                return InternalServerError(); //user shuld not know what is wrong, admin should only know
            }
        }

    }
}
