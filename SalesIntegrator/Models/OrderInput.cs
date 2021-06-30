using System;

namespace SalesIntegrator.Models
{
    public class OrderInput
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
