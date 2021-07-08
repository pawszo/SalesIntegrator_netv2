﻿using SalesIntegrator.Dto.Interface;
using Newtonsoft.Json;
using System;

namespace SalesIntegrator.Dto.Baselinker
{
    [JsonObject(Title = "OrderInput")]
    public class OrderInputDto : IOrderInputDto
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
