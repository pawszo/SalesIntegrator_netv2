using SalesIntegrator.Models;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Services
{
    public interface IDataService
    {
        List<Order> Orders { get; set; }
        string Token { get; set; }
        DBConnectionModel DBConnect { get; set; }
        InsertUserModel InsertUser { get; set; }
        InsERT.Subiekt Subiekt { get; set; }
        InsERT.GT GT { get; set; }
        dynamic OrdersResult { get; set; }

    }
}
