namespace Client
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblOldServer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNewServer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPort);
            this.panel1.Controls.Add(this.lblIp);
            this.panel1.Controls.Add(this.lblOldServer);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.ForeColor = System.Drawing.Color.White;
            this.lblPort.Location = new System.Drawing.Point(12, 65);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 15);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.ForeColor = System.Drawing.Color.White;
            this.lblIp.Location = new System.Drawing.Point(12, 37);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(23, 15);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "IP: ";
            // 
            // lblOldServer
            // 
            this.lblOldServer.AutoSize = true;
            this.lblOldServer.ForeColor = System.Drawing.Color.White;
            this.lblOldServer.Location = new System.Drawing.Point(12, 12);
            this.lblOldServer.Name = "lblOldServer";
            this.lblOldServer.Size = new System.Drawing.Size(82, 15);
            this.lblOldServer.TabIndex = 0;
            this.lblOldServer.Text = "Current Server";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnChange);
            this.panel2.Controls.Add(this.txtPort);
            this.panel2.Controls.Add(this.txtIp);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblNewServer);
            this.panel2.Location = new System.Drawing.Point(13, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 130);
            this.panel2.TabIndex = 3;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(149, 95);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 4;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(12, 66);
            this.txtPort.Name = "txtPort";
            this.txtPort.PlaceholderText = "Insert new PORT";
            this.txtPort.Size = new System.Drawing.Size(212, 23);
            this.txtPort.TabIndex = 3;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(12, 37);
            this.txtIp.Name = "txtIp";
            this.txtIp.PlaceholderText = "Insert new IP";
            this.txtIp.Size = new System.Drawing.Size(212, 23);
            this.txtIp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // lblNewServer
            // 
            this.lblNewServer.AutoSize = true;
            this.lblNewServer.ForeColor = System.Drawing.Color.White;
            this.lblNewServer.Location = new System.Drawing.Point(12, 12);
            this.lblNewServer.Name = "lblNewServer";
            this.lblNewServer.Size = new System.Drawing.Size(66, 15);
            this.lblNewServer.TabIndex = 0;
            this.lblNewServer.Text = "New Server";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(264, 264);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label lblPort;
        private Label lblIp;
        private Label lblOldServer;
        private Panel panel2;
        private Button btnChange;
        private TextBox txtPort;
        private TextBox txtIp;
        private Label label2;
        private Label lblNewServer;
    }
}