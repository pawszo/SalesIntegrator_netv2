using SalesIntegrator.Models;
using SalesIntegrator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesIntegrator.Views
{
    public partial class LoginForm : Form
    {


        public LoginForm()
        {
            InitializeComponent();

        }

        private void Start(object sender, EventArgs e)
        {
            Program.DBUser = GetConnectionModel();
            Program.InsertUser = GetInsertUserModel();
            this.Close();           
        }

        public DBConnectionModel GetConnectionModel()
        {
            return new DBConnectionModel(
                serverTextBox.Text,
                dbTextBox.Text,
                usernameTextBox.Text,
                passwordTextBox.Text);
        }
        public InsertUserModel GetInsertUserModel()
        {
            return new InsertUserModel(insertUserTextBox.Text, insertUserPasswordTextBox.Text);
        }
    }
}
