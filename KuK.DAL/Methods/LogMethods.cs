using KuK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuK.DAL.Methods
{
    public class LogMethods
    {
        private KuKContext _context = new KuKContext { };
        public bool AddError(string text, int userID)
        {
            bool result = false; //is false but it is more readable this way
            var log = new kukMessage { };
            log.MessageType = 0;
            log.Message = text;
            log.UserID = userID;

            try
            {
                _context.Messages.Add(log);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex) //antipatern every exception shuld be threated other but we expect only db excepions since we have a litle logic 
            {
                AddError(ex.Message, userID);
            }
            return result;
        }
    }
}
