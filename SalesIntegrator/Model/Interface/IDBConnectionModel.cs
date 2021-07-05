using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Model.Interface
{
    public interface IDBConnectionModel : ILoginModel
    {
        string ServerName { get; set; }
        string DatabaseName { get; set; }
    }
}
