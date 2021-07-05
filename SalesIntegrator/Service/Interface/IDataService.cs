using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Service.Interface
{
    public interface IDataService
    {
        IEnumerable<Order> Orders { get; set; }
        string Token { get; set; }
        IDBConnectionModel DBConnection { get; set; }
        ILoginModel ERPLogin { get; set; }
    }
}
