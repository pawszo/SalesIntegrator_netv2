using SalesIntegrator.Controllers;
using SalesIntegrator.Models;
using SalesIntegrator.Utils;
using SalesIntegrator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Convert = SalesIntegrator.Utils.Convert;
using SalesIntegrator.Interfaces;

namespace SalesIntegrator.Views
{
    public partial class Window : Form
    {
        public List<Control> OptionalControls { get; set; }
        private IDataService _dataService;
        private IController _controller;

        public Window()
        {
         
        }
        public void Initialize(IDataService dataService, IController controller)
        {
            _dataService = dataService;
            _controller = controller;
            InitializeComponent();
        }
        public string GetToken()
        {
            return tokenBox.Text;
        }


        private async void GetOrdersButton_Click(object sender, EventArgs e)
        {
            try 
            {
                _dataService.Token = GetToken();

                var orderInput = GetOrderInput();
            if (orderInput == null)
            {
                NonBlockingConsole.WriteLine("Found no order entries that satisfy given criteria.");
                return;
            }

            _dataService.Orders = await _controller.GetOrders(orderInput);
            this.getOrdersButton.BackColor = Color.Green;
            }
            catch
            {
                NonBlockingConsole.WriteLine("API connection failed. Review input and try again.");
            }
        }

        private OrderInput GetOrderInput()
        {
            if (!ValidateFilters())
            {
                return null;
            }
            OrderInput orderInput = new OrderInput();
            if (string.IsNullOrWhiteSpace(orderIdTextBox.Text)) orderInput.Order_id = null;
            else orderInput.Order_id = int.Parse(orderIdTextBox.Text);
            if(string.IsNullOrWhiteSpace(dateConfFromTextBox.Text))  orderInput.Date_confirmed_from = null; 
            else orderInput.Date_confirmed_from = Convert.DateStringToUnixTimestamp(dateConfFromTextBox.Text);
            if(string.IsNullOrWhiteSpace(dateFromTextBox.Text)) orderInput.Date_from = null;
            else orderInput.Date_from = Convert.DateStringToUnixTimestamp(dateFromTextBox.Text);
            if(string.IsNullOrWhiteSpace(idFromTextBox.Text)) orderInput.Id_from = null; 
            else orderInput.Id_from = int.Parse(idFromTextBox.Text);
            string getUnconfOrders = getUnconfOrdersComboBox.SelectedItem as string;
            switch (getUnconfOrders)
            {
                case "YES":
                    orderInput.Get_unconfirmed_orders = true;
                    break;
                case "NO":
                    orderInput.Get_unconfirmed_orders = false;
                    break;
                default:
                    orderInput.Get_unconfirmed_orders = null;
                    break;
            }
            if(string.IsNullOrWhiteSpace(statusIdTextBox.Text)) orderInput.Status_id = null;
            else orderInput.Status_id = int.Parse(statusIdTextBox.Text);
            if (string.IsNullOrWhiteSpace(filterEmailTextBox.Text)) orderInput.Filter_email = null;
            else orderInput.Filter_email = filterEmailTextBox.Text;
            return orderInput;
        }

        private bool ValidateFilters()
        {
            var validations = new List<bool>();
            validations.Add(string.IsNullOrWhiteSpace(orderIdTextBox.Text) || int.TryParse(orderIdTextBox.Text, out _));
            validations.Add(string.IsNullOrWhiteSpace(dateConfFromTextBox.Text) || DateTime.TryParseExact(dateConfFromTextBox.Text, Constants.DATE_FORMAT, Constants.CULTURE, DateTimeStyles.None, out _));
            validations.Add(string.IsNullOrWhiteSpace(dateFromTextBox.Text) || DateTime.TryParseExact(dateFromTextBox.Text, Constants.DATE_FORMAT, Constants.CULTURE, DateTimeStyles.None, out _));
            validations.Add(string.IsNullOrWhiteSpace(idFromTextBox.Text) || int.TryParse(idFromTextBox.Text, out _));
            validations.Add(string.IsNullOrWhiteSpace(statusIdTextBox.Text) || int.TryParse(statusIdTextBox.Text, out _));
            try
            {
                if (string.IsNullOrWhiteSpace(filterEmailTextBox.Text)) validations.Add(true);
                else
                {
                    MailAddress m = new MailAddress(filterEmailTextBox.Text);
                    validations.Add(true);
                }
            }
            catch (FormatException)
            {
                validations.Add(false);
            }
            int filterCount = 0;
            while (filterCount <= 5)
            {
                if (validations[filterCount] == false) NonBlockingConsole.WriteLine($"Incorrect format of filter {filterCount + 1}");
                filterCount++;
            }
            return validations.All(f => f == true);
        }

        private void UploadOrdersButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        
    }
}
