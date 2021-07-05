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

        private readonly IAPIService _apiService;
        private readonly IDataService _dataService;
        private readonly IERPService _erpService;

        private delegate DialogResult SafeCallDelegate();
        public IEnumerable<Order> ReceivedOrders { get; set; }

        public Form Window { get; set; }




        public Controller(IDataService dataService, IAPIService apiService, IERPService erpService)
        {
            _dataService = dataService;
            _apiService = apiService;
            _erpService = erpService;
        }

        public async Task GetOrders(IOrderInputDto orderInput)
        {
            var newOrders = await _apiService.GetOrders(orderInput);
            var orders = new List<Order>(_dataService.Orders);
            if (newOrders.Count() == 0)
            {
                NonBlockingConsole.WriteLine("No orders founds. Review your input and try again");
            }
            else
            {
                orders.AddRange(newOrders.Cast<Order>().Where(p => !orders.Contains(p)));


                foreach (var order in orders)
                {
                    NonBlockingConsole.WriteLine($"Downloaded new order: id {order.order_id}, user {order.user_login}");
                }
            }
            _dataService.Orders = orders;
        }
        public void RegisterOrders()
        {
            if (_erpService is IStartable)
            {
                (_erpService as IStartable).Start(_dataService.DBConnection, _dataService.ERPLogin);
            }
            _erpService.RegisterOrders(_dataService.Orders);
            if (_erpService is IClosable)
            {
                (_erpService as IClosable).Close();

            }
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
        public void Authorize()
        {
            IDBConnectionModel dbUser = new DBConnectionModel();
            ILoginModel erpUser = new InsertUserModel();
            LoginForm loginForm = new LoginForm(dbUser, erpUser);
            loginForm.ShowDialog();
            _dataService.DBConnection = dbUser;
            _dataService.ERPLogin = erpUser;

        }

        public IDataService GetDataService()
        {
            return _dataService;
        }
    }
}
