using KuK.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KuK.DAL
{
    public class UserMethods
    {
        private KuKContext _context = new KuKContext { };
        public bool AddUser(string firstName, string lastName, string passwordHash, string emailAddress)
        {
            bool result = false; //is false but it is more readable this way
            var user = new kukUser
            {
                FirstName = firstName,
                LastName = lastName,
                PassworHash = passwordHash,
                Email = emailAddress,
                IsConfirmed = false,
            };
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                result = true;
            }
            catch (Exception ex) //antipatern but catch any exception an log it later, every exception shuld be threated other but we expect only db excepions since we have a litle logic 
            {
                throw ex; //thow old exception to not lose stacktrace
            }
            return result;
        }

        public List<kukUser> GetUsers()
        {
            var list = _context.Users.ToList();
            return list;
        }
    }
}
