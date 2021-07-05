using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Model.Interface
{
    public interface ILoginModel : IModel
    {
        string Username { get; set; }
        string Password { get; set; }
        void SetFields(IModel model);
        void SetFields(IDictionary<string, string> fields);
    }
}
