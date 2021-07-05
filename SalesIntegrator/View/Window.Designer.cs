using SalesIntegrator.Utils;
using System.Threading.Tasks;
using SalesIntegrator.View;

namespace SalesIntegrator.View
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tokenBox = new System.Windows.Forms.PlaceholderTextBox();
            this.tokenGroup = new System.Windows.Forms.GroupBox();
            this.getOrdersButton = new System.Windows.Forms.Button();
            this.orderFilterBox = new System.Windows.Forms.GroupBox();
            this.filterEmailTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.filterEmailLabel = new System.Windows.Forms.Label();
            this.statusIdTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.statusIdLabel = new System.Windows.Forms.Label();
            this.getUnconfOrdersComboBox = new System.Windows.Forms.ComboBox();
            this.getUnconfOrdersLabel = new System.Windows.Forms.Label();
            this.idFromTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.idFromLabel = new System.Windows.Forms.Label();
            this.dateFromTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.dateConfFromTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.dateConfFromLabel = new System.Windows.Forms.Label();
            this.orderIdTextBox = new System.Windows.Forms.PlaceholderTextBox();
            this.orderIdLabel = new System.Windows.Forms.Label();
            this.uploadOrdersButton = new System.Windows.Forms.Button();
            this.tokenGroup.SuspendLayout();
            this.orderFilterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tokenBox
            // 
            this.tokenBox.Location = new System.Drawing.Point(6, 22);
            this.tokenBox.Name = "tokenBox";
            this.tokenBox.PlaceholderText = "Your Baselinker account API token";
            this.tokenBox.Size = new System.Drawing.Size(356, 20);
            this.tokenBox.TabIndex = 0;
            // 
            // tokenGroup
            // 
            this.tokenGroup.Controls.Add(this.tokenBox);
            this.tokenGroup.Location = new System.Drawing.Point(12, 12);
            this.tokenGroup.Name = "tokenGroup";
            this.tokenGroup.Size = new System.Drawing.Size(368, 50);
            this.tokenGroup.TabIndex = 0;
            this.tokenGroup.TabStop = false;
            this.tokenGroup.Text = "Baselinker API token";
            // 
            // getOrdersButton
            // 
            this.getOrdersButton.Location = new System.Drawing.Point(60, 369);
            this.getOrdersButton.Name = "getOrdersButton";
            this.getOrdersButton.Size = new System.Drawing.Size(60, 23);
            this.getOrdersButton.TabIndex = 13;
            this.getOrdersButton.Text = "Get orders";
            this.getOrdersButton.UseVisualStyleBackColor = true;
            this.getOrdersButton.Click += new System.EventHandler(this.GetOrdersButton_Click);
            //
            // uploadOrdersButton
            //
            this.uploadOrdersButton.Location = new System.Drawing.Point(210, 369);
            this.uploadOrdersButton.Name = "uploadOrdersButton";
            this.uploadOrdersButton.Size = new System.Drawing.Size(60, 23);
            this.uploadOrdersButton.TabIndex = 14;
            this.uploadOrdersButton.Text = "Register orders";
            this.uploadOrdersButton.UseVisualStyleBackColor = true;
            this.uploadOrdersButton.Click += new System.EventHandler(this.UploadOrdersButton_Click);

            // 
            // orderFilterBox
            // 
            this.orderFilterBox.Controls.Add(this.filterEmailTextBox);
            this.orderFilterBox.Controls.Add(this.filterEmailLabel);
            this.orderFilterBox.Controls.Add(this.statusIdTextBox);
            this.orderFilterBox.Controls.Add(this.statusIdLabel);
            this.orderFilterBox.Controls.Add(this.getUnconfOrdersComboBox);
            this.orderFilterBox.Controls.Add(this.getUnconfOrdersLabel);
            this.orderFilterBox.Controls.Add(this.idFromTextBox);
            this.orderFilterBox.Controls.Add(this.idFromLabel);
            this.orderFilterBox.Controls.Add(this.dateFromTextBox);
            this.orderFilterBox.Controls.Add(this.dateFromLabel);
            this.orderFilterBox.Controls.Add(this.dateConfFromTextBox);
            this.orderFilterBox.Controls.Add(this.dateConfFromLabel);
            this.orderFilterBox.Controls.Add(this.orderIdTextBox);
            this.orderFilterBox.Controls.Add(this.orderIdLabel);
            this.orderFilterBox.Location = new System.Drawing.Point(12, 69);
            this.orderFilterBox.Name = "orderFilterBox";
            this.orderFilterBox.Size = new System.Drawing.Size(368, 221);
            this.orderFilterBox.TabIndex = 1;
            this.orderFilterBox.TabStop = false;
            this.orderFilterBox.Text = "Order filters";
            // 
            // filterEmailTextBox
            // 
            this.filterEmailTextBox.Location = new System.Drawing.Point(173, 161);
            this.filterEmailTextBox.Name = "filterEmailTextBox";
            this.filterEmailTextBox.PlaceholderText = "optional";
            this.filterEmailTextBox.Size = new System.Drawing.Size(189, 20);
            this.filterEmailTextBox.TabIndex = 7;
            // 
            // filterEmailLabel
            // 
            this.filterEmailLabel.AutoSize = true;
            this.filterEmailLabel.Location = new System.Drawing.Point(7, 165);
            this.filterEmailLabel.Name = "filterEmailLabel";
            this.filterEmailLabel.Size = new System.Drawing.Size(71, 13);
            this.filterEmailLabel.Text = "6. Filter_email";
            // 
            // statusIdTextBox
            // 
            this.statusIdTextBox.Location = new System.Drawing.Point(173, 133);
            this.statusIdTextBox.Name = "statusIdTextBox";
            this.statusIdTextBox.PlaceholderText = "optional";
            this.statusIdTextBox.Size = new System.Drawing.Size(189, 20);
            this.statusIdTextBox.TabIndex = 6;
            // 
            // statusIdLabel
            // 
            this.statusIdLabel.AutoSize = true;
            this.statusIdLabel.Location = new System.Drawing.Point(7, 137);
            this.statusIdLabel.Name = "statusIdLabel";
            this.statusIdLabel.Size = new System.Drawing.Size(63, 13);
            this.statusIdLabel.Text = "5. Status_id";
            // 
            // getUnconfOrdersComboBox
            // 
            this.getUnconfOrdersComboBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.getUnconfOrdersComboBox.FormattingEnabled = true;
            this.getUnconfOrdersComboBox.Items.AddRange(new object[] {
            "YES",
            "NO",
            "(blank)"});
            this.getUnconfOrdersComboBox.Location = new System.Drawing.Point(173, 190);
            this.getUnconfOrdersComboBox.Name = "getUnconfOrdersComboBox";
            this.getUnconfOrdersComboBox.Size = new System.Drawing.Size(189, 21);
            this.getUnconfOrdersComboBox.TabIndex = 8;
            this.getUnconfOrdersComboBox.Text = "select value <optional>";
            // 
            // getUnconfOrdersLabel
            // 
            this.getUnconfOrdersLabel.AutoSize = true;
            this.getUnconfOrdersLabel.Location = new System.Drawing.Point(7, 193);
            this.getUnconfOrdersLabel.Name = "getUnconfOrdersLabel";
            this.getUnconfOrdersLabel.Size = new System.Drawing.Size(135, 13);
            this.getUnconfOrdersLabel.Text = "7. Get_unconfirmed_orders";
            // 
            // idFromTextBox
            // 
            this.idFromTextBox.Location = new System.Drawing.Point(173, 104);
            this.idFromTextBox.Name = "idFromTextBox";
            this.idFromTextBox.PlaceholderText = "optional";
            this.idFromTextBox.Size = new System.Drawing.Size(189, 20);
            this.idFromTextBox.TabIndex = 4;
            // 
            // idFromLabel
            // 
            this.idFromLabel.AutoSize = true;
            this.idFromLabel.Location = new System.Drawing.Point(6, 108);
            this.idFromLabel.Name = "idFromLabel";
            this.idFromLabel.Size = new System.Drawing.Size(54, 13);
            this.idFromLabel.Text = "4. Id_from";
            // 
            // dateFromTextBox
            // 
            this.dateFromTextBox.Location = new System.Drawing.Point(173, 77);
            this.dateFromTextBox.Name = "dateFromTextBox";
            this.dateFromTextBox.PlaceholderText = "optional";
            this.dateFromTextBox.Size = new System.Drawing.Size(189, 20);
            this.dateFromTextBox.TabIndex = 3;
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.Location = new System.Drawing.Point(7, 77);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(68, 13);
            this.dateFromLabel.TabIndex = 3;
            this.dateFromLabel.Text = "3. Date_from";
            // 
            // dateConfFromTextBox
            // 
            this.dateConfFromTextBox.Location = new System.Drawing.Point(173, 48);
            this.dateConfFromTextBox.Name = "dateConfFromTextBox";
            this.dateConfFromTextBox.PlaceholderText = "optional";
            this.dateConfFromTextBox.Size = new System.Drawing.Size(189, 20);
            this.dateConfFromTextBox.TabIndex = 2;
            // 
            // dateConfFromLabel
            // 
            this.dateConfFromLabel.AutoSize = true;
            this.dateConfFromLabel.Location = new System.Drawing.Point(7, 48);
            this.dateConfFromLabel.Name = "dateConfFromLabel";
            this.dateConfFromLabel.Size = new System.Drawing.Size(120, 13);
            this.dateConfFromLabel.Text = "2. Date_confirmed_from";
            // 
            // orderIdTextBox
            // 
            this.orderIdTextBox.Location = new System.Drawing.Point(173, 19);
            this.orderIdTextBox.Name = "orderIdTextBox";
            this.orderIdTextBox.PlaceholderText = "optional";
            this.orderIdTextBox.Size = new System.Drawing.Size(189, 20);
            this.orderIdTextBox.TabIndex = 1;
            // 
            // orderIdLabel
            // 
            this.orderIdLabel.AutoSize = true;
            this.orderIdLabel.Location = new System.Drawing.Point(7, 23);
            this.orderIdLabel.Name = "orderIdLabel";
            this.orderIdLabel.Size = new System.Drawing.Size(59, 13);
            this.orderIdLabel.Text = "1. Order_id";


           
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 420);
            this.Controls.Add(this.orderFilterBox);
            this.Controls.Add(this.getOrdersButton);
            this.Controls.Add(this.uploadOrdersButton);
            this.Controls.Add(this.tokenGroup);
            this.Name = "Window";
            this.Text = "Sales Integrator";
            this.tokenGroup.ResumeLayout(false);
            this.tokenGroup.PerformLayout();
            this.orderFilterBox.ResumeLayout(false);
            this.orderFilterBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox tokenGroup;
        private System.Windows.Forms.Button getOrdersButton;
        private System.Windows.Forms.GroupBox orderFilterBox;
        private System.Windows.Forms.Label dateFromLabel;
        private System.Windows.Forms.Label dateConfFromLabel;
        private System.Windows.Forms.Label orderIdLabel;
        private System.Windows.Forms.ComboBox getUnconfOrdersComboBox;
        private System.Windows.Forms.Label getUnconfOrdersLabel;
        private System.Windows.Forms.Label idFromLabel;
        private System.Windows.Forms.Label filterEmailLabel;
        private System.Windows.Forms.Label statusIdLabel;       
        private System.Windows.Forms.Button uploadOrdersButton;
        private System.Windows.Forms.PlaceholderTextBox tokenBox;
        private System.Windows.Forms.PlaceholderTextBox dateFromTextBox;
        private System.Windows.Forms.PlaceholderTextBox dateConfFromTextBox;
        private System.Windows.Forms.PlaceholderTextBox orderIdTextBox;
        private System.Windows.Forms.PlaceholderTextBox idFromTextBox;
        private System.Windows.Forms.PlaceholderTextBox filterEmailTextBox;
        private System.Windows.Forms.PlaceholderTextBox statusIdTextBox;
        
        
    }
}

