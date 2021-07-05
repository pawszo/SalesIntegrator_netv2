using SalesIntegrator.Service.Interface;
using SalesIntegrator.Model;
using System;
using System.Collections.Generic;
using SalesIntegrator.Model.Interface;

namespace SalesIntegrator.Service
{
    public class DataService : IDataService
    {

        public IEnumerable<Order> Orders { get; set; }
        public string Token { get; set; }
        public IDBConnectionModel DBConnection { get; set; }
        public ILoginModel ERPLogin { get; set; }




        public DataService()
        {
            Orders = new List<Order>();

        }

    }

    
}
