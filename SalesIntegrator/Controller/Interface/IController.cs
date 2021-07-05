using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Model;
using SalesIntegrator.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesIntegrator.Controller.Interface
{
    public interface IController
    {
        Form Window { get; set; }

        Task GetOrders(IOrderInputDto orderInput);
        void Initialize();
        IEnumerable<Order> ReceivedOrders { get; set; }
        IDataService GetDataService();


    }
}
