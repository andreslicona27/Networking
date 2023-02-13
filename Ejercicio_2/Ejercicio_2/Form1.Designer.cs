namespace Ejercicio_2
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
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnList = new System.Windows.Forms.Button();
            this.btnServer = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelActions
            // 
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.btnList);
            this.panelActions.Controls.Add(this.btnServer);
            this.panelActions.Controls.Add(this.btnAdd);
            this.panelActions.Location = new System.Drawing.Point(12, 46);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(183, 85);
            this.panelActions.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(93, 15);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 1;
            this.btnList.Tag = "list";
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnServer
            // 
            this.btnServer.Location = new System.Drawing.Point(12, 44);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(156, 23);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Tag = "add";
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btn_Click);
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(51, 17);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(144, 23);
            this.tbUser.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "User:";
            // 
            // tbInfo
            // 
            this.tbInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbInfo.Location = new System.Drawing.Point(214, 17);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(496, 114);
            this.tbInfo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 144);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.panelActions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Shift Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelActions;
        private Button btnList;
        private Button btnAdd;
        private Button btnServer;
        private TextBox tbUser;
        private Label label1;
        private TextBox tbInfo;
    }
}