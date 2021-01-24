using KuK.DAL.Methods;
using KuK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuK.Services
{
    public class NoticeService
    {
        private NoticeMethods _methods = new NoticeMethods();

        public bool AddNotice(string text, int userID)
        {
            bool result = false; //is false but it is more readable this way
            var notice = new kukNotice { };
            notice.Text = text;
            notice.Date = DateTime.Now;

            try
            {
                _methods.AddNotice(text, userID);
                result = true;
            }
            catch (Exception ex) //antipatern but catch any exception an log it later, every exception shuld be threated other but we expect only db excepions since we have a litle logic 
            {
                throw ex; //thow old exception to not lose stacktrace
            }
            return result;
        }

        public List<kukNotice> GetAllNotices(int userID)
        {
            var list = _methods.GetAllNotices(userID);
            return list;
        }

        public List<kukNotice> GetAllNoticesByDate(int userID, DateTime date)//you could have more notices on the same day
        {
            var list = _methods.GetAllNoticesByDate(userID, date);
            return list;
        }
        public bool EditNotice(int userID, int noticeID, string text)
        {
            bool result = false; //is false but it is more readable this way
            try
            {
                _methods.EditNotice(userID, noticeID, text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DelateNotice(int userID, int noticeID)
        {
            bool result = false; //is false but it is more readable this way
            try
            {
                _methods.DelateNotice(userID, noticeID);
                result = true;
            }
            catch (Exception ex) //antipatern but catch any exception an log it later, every exception shuld be threated other but we expect only db excepions since we have a litle logic 
            {
                //do  someting to retry
                throw ex; //thow old exception to not lose stacktrace
            }
            return result;
        }
    }
}
