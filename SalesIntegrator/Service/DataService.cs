using SalesIntegrator.Service.Interface;
using SalesIntegrator.Model;
using System;
using System.Collections.Generic;

namespace SalesIntegrator.Service
{
    public class DataService : IDataService
    {

        public IEnumerable<Order> Orders { get; set; }
        public string Token { get; set; }
        public DBConnectionModel DBConnect { get; set; }
        public InsertUserModel InsertUser { get; set; }




        public DataService()
        {
            Orders = new List<Order>();

        }

    }

    
}
