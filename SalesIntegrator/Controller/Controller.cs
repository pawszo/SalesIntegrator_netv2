using SalesIntegrator.Dto.Interface;
using SalesIntegrator.Service.Interface;
using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using SalesIntegrator.Utils;
using SalesIntegrator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesIntegrator.Controller.Interface;

namespace SalesIntegrator.Controller
{
    public sealed class Controller : IController
    {

        private readonly IAPIService _baselinkerService;
        private readonly IDataService _dataService;

        private delegate DialogResult SafeCallDelegate();
        public IEnumerable<Order> ReceivedOrders { get; set; }

        public Form Window { get; set; }




        public Controller(IDataService dataService, IAPIService baselinkerService)
        {
            _dataService = dataService;
            _baselinkerService = baselinkerService;
        }

        public async Task GetOrders(IOrderInputDto orderInput)
        {
            var newOrders = await _baselinkerService.GetOrders(orderInput);
            if (newOrders.Count() == 0)
            {
                NonBlockingConsole.WriteLine("No orders founds. Review your input and try again");
            }
            else
            {
                var orders = new List<Order>(_dataService.Orders);
                orders.AddRange(newOrders.Cast<Order>().Where(p => !orders.Contains(p)));


                foreach (var order in orders)
                {
                    NonBlockingConsole.WriteLine($"Downloaded new order: id {order.order_id}, user {order.user_login}");
                }
            }
            //ReceivedOrders = newOrders;
            //return newOrders;

        }


        public void Initialize()
        {
            Window = new Window { Visible = false };
            (Window as Window).Initialize(_dataService, this);

            if((Window as Window).InvokeRequired)
            {
                var d = new SafeCallDelegate(Window.ShowDialog);
                (Window as Window).Invoke(d);
            }
            else Window.ShowDialog();
        }

        public IDataService GetDataService()
        {
            return _dataService;
        }
    }
}
