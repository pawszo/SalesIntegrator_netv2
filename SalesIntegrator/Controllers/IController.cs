using SalesIntegrator.Models;
using SalesIntegrator.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesIntegrator.Controllers
{
    public interface IController
    {
        Form Window { get; set; }
        Form LogConsole { get; set; }

        Task GetOrders(OrderInput orderInput);
        void Initialize();
        IEnumerable<Order> ReceivedOrders { get; set; }
        IDataService GetDataService();


    }
}
