
namespace SalesIntegrator.View
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.loginButton = new System.Windows.Forms.Button();
            this.subiektGroupBox = new System.Windows.Forms.GroupBox();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.insertUserPasswordTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.insertUserTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.dbGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.usernameTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.dbTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.serverTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.subiektGroupBox.SuspendLayout();
            this.userGroupBox.SuspendLayout();
            this.dbGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(144, 211);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(88, 35);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Launch";
            this.loginButton.Click += new System.EventHandler(this.Start);
            // 
            // subiektGroupBox
            // 
            this.subiektGroupBox.Controls.Add(this.userGroupBox);
            this.subiektGroupBox.Controls.Add(this.dbGroupBox);
            this.subiektGroupBox.Location = new System.Drawing.Point(12, 10);
            this.subiektGroupBox.Name = "subiektGroupBox";
            this.subiektGroupBox.Size = new System.Drawing.Size(368, 179);
            this.subiektGroupBox.TabIndex = 6;
            this.subiektGroupBox.TabStop = false;
            this.subiektGroupBox.Text = "Subiekt GT";
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.insertUserPasswordTextBox);
            this.userGroupBox.Controls.Add(this.insertUserTextBox);
            this.userGroupBox.Location = new System.Drawing.Point(186, 23);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(176, 87);
            this.userGroupBox.TabIndex = 1;
            this.userGroupBox.TabStop = false;
            this.userGroupBox.Text = "User";
            // 
            // insertUserPasswordTextBox
            // 
            this.insertUserPasswordTextBox.Location = new System.Drawing.Point(11, 52);
            this.insertUserPasswordTextBox.Name = "insertUserPasswordTextBox";
            this.insertUserPasswordTextBox.PlaceholderText = "Password";
            this.insertUserPasswordTextBox.Size = new System.Drawing.Size(159, 20);
            this.insertUserPasswordTextBox.TabIndex = 4;
            // 
            // insertUserTextBox
            // 
            this.insertUserTextBox.Location = new System.Drawing.Point(11, 23);
            this.insertUserTextBox.Name = "insertUserTextBox";
            this.insertUserTextBox.PlaceholderText = "User (i.e. Szef)";
            this.insertUserTextBox.Size = new System.Drawing.Size(159, 20);
            this.insertUserTextBox.TabIndex = 1;
            // 
            // dbGroupBox
            // 
            this.dbGroupBox.Controls.Add(this.passwordTextBox);
            this.dbGroupBox.Controls.Add(this.usernameTextBox);
            this.dbGroupBox.Controls.Add(this.dbTextBox);
            this.dbGroupBox.Controls.Add(this.serverTextBox);
            this.dbGroupBox.Location = new System.Drawing.Point(7, 23);
            this.dbGroupBox.Name = "dbGroupBox";
            this.dbGroupBox.Size = new System.Drawing.Size(173, 142);
            this.dbGroupBox.TabIndex = 0;
            this.dbGroupBox.TabStop = false;
            this.dbGroupBox.Text = "Database connection";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(8, 110);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PlaceholderText = "Password";
            this.passwordTextBox.Size = new System.Drawing.Size(159, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(7, 81);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PlaceholderText = "Username (i.e. sa)";
            this.usernameTextBox.Size = new System.Drawing.Size(159, 20);
            this.usernameTextBox.TabIndex = 2;
            // 
            // dbTextBox
            // 
            this.dbTextBox.Location = new System.Drawing.Point(7, 52);
            this.dbTextBox.Name = "dbTextBox";
            this.dbTextBox.PlaceholderText = "Database (i.e. TestSubiekt1)";
            this.dbTextBox.Size = new System.Drawing.Size(159, 20);
            this.dbTextBox.TabIndex = 1;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(7, 23);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.PlaceholderText = "Server (i.e. (local)\\\\INSERTGT)";
            this.serverTextBox.Size = new System.Drawing.Size(159, 20);
            this.serverTextBox.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 258);
            this.Controls.Add(this.subiektGroupBox);
            this.Controls.Add(this.loginButton);
            this.Name = "LoginForm";
            this.Text = "Login to Subiekt GT";
            this.subiektGroupBox.ResumeLayout(false);
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            this.dbGroupBox.ResumeLayout(false);
            this.dbGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PlaceholderTextBox passwordTextBox;
        private System.Windows.Forms.PlaceholderTextBox usernameTextBox;
        private System.Windows.Forms.PlaceholderTextBox dbTextBox;
        private System.Windows.Forms.PlaceholderTextBox serverTextBox;
        private System.Windows.Forms.PlaceholderTextBox insertUserPasswordTextBox;
        private System.Windows.Forms.PlaceholderTextBox insertUserTextBox;
        private System.Windows.Forms.GroupBox subiektGroupBox;
        private System.Windows.Forms.GroupBox dbGroupBox;
        private System.Windows.Forms.GroupBox userGroupBox;
        private System.Windows.Forms.Button loginButton;

        #endregion
    }
}