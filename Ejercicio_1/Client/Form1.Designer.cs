namespace Client
{
    partial class Form1
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
            this.btnTime = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBoth = new System.Windows.Forms.Button();
            this.btnChangeIP = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTime
            // 
            this.btnTime.BackColor = System.Drawing.Color.Honeydew;
            this.btnTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTime.Location = new System.Drawing.Point(12, 150);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(117, 23);
            this.btnTime.TabIndex = 0;
            this.btnTime.Tag = "time";
            this.btnTime.Text = "Time";
            this.btnTime.UseVisualStyleBackColor = false;
            this.btnTime.Click += new System.EventHandler(this.button_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 118);
            this.panel1.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "write password to close server";
            this.txtPassword.Size = new System.Drawing.Size(209, 23);
            this.txtPassword.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(15, 17);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(70, 15);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Information";
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.Honeydew;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDate.Location = new System.Drawing.Point(143, 150);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(117, 23);
            this.btnDate.TabIndex = 2;
            this.btnDate.Tag = "date";
            this.btnDate.Text = "Date";
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.button_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Honeydew;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(143, 179);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Tag = "close ";
            this.btnClose.Text = "Close Server";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button_Click);
            // 
            // btnBoth
            // 
            this.btnBoth.BackColor = System.Drawing.Color.Honeydew;
            this.btnBoth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBoth.Location = new System.Drawing.Point(12, 179);
            this.btnBoth.Name = "btnBoth";
            this.btnBoth.Size = new System.Drawing.Size(117, 23);
            this.btnBoth.TabIndex = 3;
            this.btnBoth.Tag = "all";
            this.btnBoth.Text = "Date and Time";
            this.btnBoth.UseVisualStyleBackColor = false;
            this.btnBoth.Click += new System.EventHandler(this.button_Click);
            // 
            // btnChangeIP
            // 
            this.btnChangeIP.BackColor = System.Drawing.Color.Honeydew;
            this.btnChangeIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeIP.Location = new System.Drawing.Point(12, 208);
            this.btnChangeIP.Name = "btnChangeIP";
            this.btnChangeIP.Size = new System.Drawing.Size(248, 23);
            this.btnChangeIP.TabIndex = 5;
            this.btnChangeIP.Text = "Change IP and Port";
            this.btnChangeIP.UseVisualStyleBackColor = false;
            this.btnChangeIP.Click += new System.EventHandler(this.btnChangeIP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.btnChangeIP);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBoth);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTime);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnTime;
        private Panel panel1;
        private TextBox txtPassword;
        private Label lblInfo;
        private Button btnDate;
        private Button btnClose;
        private Button btnBoth;
        private Button btnChangeIP;
    }
}