using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Models
{
    public class InsertUserModel
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public InsertUserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
