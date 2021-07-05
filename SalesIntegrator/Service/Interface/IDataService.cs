using SalesIntegrator.Model;
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
        DBConnectionModel DBConnect { get; set; }
        InsertUserModel InsertUser { get; set; }
    }
}
