using SalesIntegrator.Interfaces;
using SalesIntegrator.Models;
using System;
using System.Collections.Generic;

namespace SalesIntegrator.Services
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
