using SalesIntegrator.Model;
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

namespace SalesIntegrator.View
{
    public partial class LoginForm : Form
    {
        private InsertUserModel _insertUser;
        private DBConnectionModel _dbUser;

        public LoginForm(DBConnectionModel dbUser, InsertUserModel insertUser)
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
            _dbUser.SetFields(
                serverTextBox.Text,
                dbTextBox.Text,
                usernameTextBox.Text,
                passwordTextBox.Text);
        }
        public void GetInsertUserModel()
        {
            _insertUser.SetFields(insertUserTextBox.Text, insertUserPasswordTextBox.Text);
        }
    }
}
