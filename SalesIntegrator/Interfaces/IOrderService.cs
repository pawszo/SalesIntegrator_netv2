using SalesIntegrator.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesIntegrator.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders(OrderInput input);
    }
}
