using KuK.DAL;
using KuK.Model;
using System;
using System.Collections.Generic;

namespace KuK.Service
{
    public class UserService
    {
        private UserMethods _methods = new UserMethods();
        public bool AddUser(string firstName, string lastName, string passwordHash, string emailAddress)
        {
            bool result = false; //see comment in method
            try
            {
                _methods.AddUser(firstName, lastName, passwordHash, emailAddress);
                result = true;
            }
            catch (Exception ex)//see comment in method
            {
                throw ex;
            }
            return result;
        }

        public List<kukUser> GetUsers()
        {
            var list = _methods.GetUsers();
            return list;
        }
    }
}
