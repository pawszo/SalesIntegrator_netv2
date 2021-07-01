using SalesIntegrator.Models;
using SalesIntegrator.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesIntegrator.Interfaces
{
    public interface IController : IOrderService
    {
        Form Window { get; set; }

        //Task<IEnumerable<Order>> GetOrders(OrderInput orderInput);
        void Initialize();
        IEnumerable<Order> ReceivedOrders { get; set; }
        IDataService GetDataService();


    }
}
