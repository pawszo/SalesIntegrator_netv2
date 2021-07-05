using SalesIntegrator.Model;
using SalesIntegrator.Model.Interface;
using SalesIntegrator.Service;
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
using System.Collections.Generic;

namespace SalesIntegrator.View
{
    public partial class LoginForm : Form
    {
        private ILoginModel _insertUser;
        private IDBConnectionModel _dbUser;

        public LoginForm(IDBConnectionModel dbUser, ILoginModel insertUser)
        { 
            InitializeComponent();
            _insertUser = insertUser;
            _dbUser = dbUser;

        }


        private void Start(object sender, EventArgs e)
        {
            GetConnectionModel();
            GetInsertUserModel();
            this.Close();           
        }

        public void GetConnectionModel()
        {
            var fields = new Dictionary<string, string>();
            fields.Add("serverName", serverTextBox.Text);
            fields.Add("dbName", dbTextBox.Text);
            fields.Add("username", usernameTextBox.Text);
            fields.Add("password", passwordTextBox.Text);

            _dbUser.SetFields(fields);
        }
        public void GetInsertUserModel()
        {
            var fields = new Dictionary<string, string>();
            fields.Add("username", insertUserTextBox.Text);
            fields.Add("password", insertUserPasswordTextBox.Text);
            _insertUser.SetFields(fields);
        }
    }
}
