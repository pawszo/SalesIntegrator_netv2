using SalesIntegrator.Utils;
using System.Windows.Forms;

namespace SalesIntegrator.Views
{
    partial class LogConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ListBox logConsoleDisplay = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logConsoleDisplay = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // logConsoleDisplay
            // 
            this.logConsoleDisplay.Location = new System.Drawing.Point(15, 17);
            this.logConsoleDisplay.Name = "logConsoleDisplay";
            this.logConsoleDisplay.Size = new System.Drawing.Size(610, 602);
            this.logConsoleDisplay.TabIndex = 0;
            // 
            // LogConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 640);
            this.Controls.Add(this.logConsoleDisplay);
            this.Name = "LogConsole";
            this.Text = "LogConsole";
            this.ResumeLayout(false);

        }

        #endregion
    }
}