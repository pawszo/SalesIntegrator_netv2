using SalesIntegrator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Model
{
    public class OrderResult : IModel
    {
        public string status { get; set; }

        public Order[] orders { get; set; }
    }
}
