using SalesIntegrator.Controllers;
using SalesIntegrator.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesIntegrator.Views
{
    public partial class LogConsole : Form
    {
        private delegate void SafeCallDelegate(string text);

        public LogConsole()
        {
            InitializeComponent();
        }


        public void PrintStatus(string text)
        {
            if(logConsoleDisplay.InvokeRequired)
            {
                var d = new SafeCallDelegate(PrintStatus);
                logConsoleDisplay.Invoke(d, new object[] { text });
            }
            else logConsoleDisplay.Items.Add(text);
        }

        public void ShowLogDisplay()
        {
            logConsoleDisplay.Visible = true;
            logConsoleDisplay.Show();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= Constants.WS_SYSMENU;
                return cp;
            }
        }

        public Point downPoint = Point.Empty;

        protected override void OnLoad(EventArgs e)
        {

            MouseDown += new MouseEventHandler(LogConsole_MouseDown);
            MouseMove += new MouseEventHandler(LogConsole_MouseMove);
            MouseUp += new MouseEventHandler(LogConsole_MouseUp);


            base.OnLoad(e);
        }
        private void LogConsole_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                downPoint = new Point(e.X, e.Y);
        }
        private void LogConsole_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint != Point.Empty)
                Location = new Point(Left + e.X - downPoint.X, Top + e.Y - downPoint.Y);
        }
        private void LogConsole_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                downPoint = Point.Empty;
        }



    }
}
