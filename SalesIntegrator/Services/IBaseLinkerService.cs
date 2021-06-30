using SalesIntegrator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesIntegrator.Services
{
    public interface IBaseLinkerService
    {
        Task<IEnumerable<Order>> GetOrders(OrderInput input);
        Task<dynamic> GetOrdersResult(OrderInput input);
    }
}
