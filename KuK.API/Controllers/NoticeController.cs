using KuK.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KuK.API.Controllers
{
    [EnableCors("*", "*", "*")] //any origin is allowed but restrict to frontend app
    public class NoticeController : ApiController
    {
        private NoticeService _noticeService = new NoticeService { };
        private LogService _logService = new LogService { };

        [HttpGet]
        public IHttpActionResult GetAllNotices(int userID)
        {
            try
            {
                var list = _noticeService.GetAllNotices(userID);
                return Ok(list);
            }
            catch(Exception ex)
            {
                var text = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(text, userID);
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetNoticesByDate(int userID, DateTime date)
        {
            try
            {
                var list = _noticeService.GetAllNoticesByDate(userID, date);
                return Ok(list);
            }
            catch (Exception ex)
            {
                var text = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(text, userID);
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult AddNotice([FromBody]int userID, string text)
        {
            try
            {
                _noticeService.AddNotice(text, userID);
                return Ok();
            }
            catch (Exception ex)
            {
                var error = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(error, userID);
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult EditNotice([FromBody] int userID, int noticeID, string text)
        {
            try
            {
                _noticeService.EditNotice(userID, noticeID, text);
                return Ok();
            }
            catch (Exception ex)
            {
                var error = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(error, userID);
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteNotice(int userID, int noticeID)
        {
            try
            {
                _noticeService.DelateNotice(userID, noticeID);
                return Ok();
            }
            catch (Exception ex)
            {
                var error = ex.Message + " " + ex.StackTrace.ToString();
                _logService.AddError(error, userID);
                return InternalServerError();
            }
        }
    }
}
