using SalesIntegrator.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Dto.Interface
{
    public interface IOrderInputDto : IDto
    {
        Nullable<int> Order_id { get; set; }
        Nullable<int> Date_confirmed_from { get; set; }
        Nullable<int> Date_from { get; set; }
        Nullable<int> Id_from { get; set; }
        Nullable<bool> Get_unconfirmed_orders { get; set; }
        Nullable<int> Status_id { get; set; }
        string Filter_email { get; set; }
    }
}
