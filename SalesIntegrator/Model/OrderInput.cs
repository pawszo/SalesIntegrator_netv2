using SalesIntegrator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Model
{
    public class OrderInput : IModel
    {
        public Nullable<int> Order_id { get; set; }
        public Nullable<int> Date_confirmed_from { get; set; }
        public Nullable<int> Date_from { get; set; }
        public Nullable<int> Id_from { get; set; }
        public Nullable<bool> Get_unconfirmed_orders { get; set; }
        public Nullable<int> Status_id { get; set; }
        public string Filter_email { get; set; }
    }
}
