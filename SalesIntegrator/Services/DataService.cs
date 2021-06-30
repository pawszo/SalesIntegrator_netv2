using SalesIntegrator.Controllers;
using SalesIntegrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADODB;
using SalesIntegrator.Utils;
using SalesIntegrator.Services;
using System.IO;
using System.Collections.Concurrent;
using System.Threading;

namespace SalesIntegrator.Services
{
    public class DataService : IDataService
    {

        public List<Order> Orders { get; set; }
        public string Token { get; set; }
        public DBConnectionModel DBConnect { get; set; }
        public InsertUserModel InsertUser { get; set; }
        public InsERT.Subiekt Subiekt { get; set; }
        public InsERT.GT GT { get; set; }
        public dynamic OrdersResult { get; set; }




        public DataService()
        {
            Orders = new List<Order>();

        }

    }

    
}
