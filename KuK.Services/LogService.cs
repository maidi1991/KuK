using KuK.DAL.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuK.Services
{
    public class LogService
    {
        private LogMethods _methods = new LogMethods();
        public void AddError(string text, int userID)
        {
            _methods.AddError(text, userID); //no try-catch blok when this goes wrong then make a big fire and burn your computer
        }
    }
}
