using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Model
{
    public class InsertUserModel
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public void SetFields(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public void SetFields(InsertUserModel model)
        {
            Username = model.Username;
            Password = model.Password;
        }
    }
}
