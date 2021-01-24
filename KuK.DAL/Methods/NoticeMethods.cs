using KuK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KuK.DAL.Methods
{
    public class NoticeMethods
    {
        private KuKContext _context = new KuKContext { };
        public bool AddNotice(string text, int userID)
        {
            bool result = false; //is false but it is more readable this way
            var notice = new kukNotice { };
            notice.Text = text;
            notice.Date = DateTime.Now;

            try
            {
                _context.Users.Where(u=> u.UserID == userID).FirstOrDefault().Notices.Add(notice);
                _context.SaveChanges();
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
            var list = _context.Users.Where(u => u.UserID == userID).FirstOrDefault().Notices.Where(n => n.Archived).ToList();
            return list;
        }

        public List<kukNotice> GetAllNoticesByDate(int userID, DateTime date)//you could have more notices on the same day
        {
            var list = _context.Users.Where(u => u.UserID == userID).FirstOrDefault().Notices.Where(n=>n.Date.Date == date.Date && !n.Archived).ToList();
            return list;
        }
        public bool EditNotice(int userID, int noticeID, string text)
        {
            bool result = false; //is false but it is more readable this way
            try
            {

                var notice = GetAllNotices(userID).Where(n => n.NoticeID == noticeID).FirstOrDefault();
                notice.Text = text;
                _context.SaveChanges();
                result = true;
            }
            catch(Exception ex)
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
                _context.Users.Where(u => u.UserID == userID).FirstOrDefault().Notices.Where(n => n.NoticeID == noticeID).FirstOrDefault().Archived = true;
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex) //antipatern but catch any exception an log it later, every exception shuld be threated other but we expect only db excepions since we have a litle logic 
            {
                //do someting to retry
                throw ex; //thow old exception to not lose stacktrace
            }
            return result;
        }
    }
}
