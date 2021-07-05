using SalesIntegrator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Model
{
    public class InsertUserModel : ILoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void SetFields(IDictionary<string, string> fields)
        {
            Username = fields["username"];
            Password = fields["password"];
        }
        public void SetFields(IModel model)
        {
            var loginModel = model as ILoginModel;
            Username = loginModel.Username;
            Password = loginModel.Password;
        }
    }
}
