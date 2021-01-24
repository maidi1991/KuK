using KuK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KuK.API.Controllers
{
    public class NoticeController : ApiController
    {
        private NoticeService _noticeService = new NoticeService { };

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
                //TO DO log exception
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
                //TO DO log exception
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
                //TO DO log exception
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult EditNotice([FromBody]int userID, int noticeID, string text)
        {
                try
                {
                    _noticeService.EditNotice(userID, noticeID, text);
                    return Ok();
                }
                catch (Exception ex)
                {
                    //TO DO log exception
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
                //TO DO log exception
                return InternalServerError();
            }
        }
    }
}
