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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.RecordsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRecords = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.RecordsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ink Free", 47.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(565, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Hanged";
            // 
            // btnPlay
            // 
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(294, 184);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(104, 34);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Tag = "getword";
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.ServerConexion);
            // 
            // btnAddWord
            // 
            this.btnAddWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWord.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddWord.ForeColor = System.Drawing.Color.White;
            this.btnAddWord.Location = new System.Drawing.Point(294, 224);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(104, 34);
            this.btnAddWord.TabIndex = 2;
            this.btnAddWord.Tag = "sendword";
            this.btnAddWord.Text = "Add Word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.ServerConexion);
            // 
            // btnRecords
            // 
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecords.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRecords.ForeColor = System.Drawing.Color.White;
            this.btnRecords.Location = new System.Drawing.Point(294, 264);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(104, 34);
            this.btnRecords.TabIndex = 3;
            this.btnRecords.Tag = "getrecords";
            this.btnRecords.Text = "Records";
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Click += new System.EventHandler(this.ServerConexion);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(294, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 34);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.playToolStripMenuItem,
            this.addWordToolStripMenuItem,
            this.recordsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.playToolStripMenuItem.Tag = "getword";
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.ServerConexion);
            // 
            // addWordToolStripMenuItem
            // 
            this.addWordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendAWordToolStripMenuItem,
            this.sendAFileToolStripMenuItem});
            this.addWordToolStripMenuItem.Name = "addWordToolStripMenuItem";
            this.addWordToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.addWordToolStripMenuItem.Text = "Add Word";
            // 
            // sendAWordToolStripMenuItem
            // 
            this.sendAWordToolStripMenuItem.Name = "sendAWordToolStripMenuItem";
            this.sendAWordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendAWordToolStripMenuItem.Tag = "sendword";
            this.sendAWordToolStripMenuItem.Text = "Send a word";
            this.sendAWordToolStripMenuItem.Click += new System.EventHandler(this.ServerConexion);
            // 
            // sendAFileToolStripMenuItem
            // 
            this.sendAFileToolStripMenuItem.Name = "sendAFileToolStripMenuItem";
            this.sendAFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendAFileToolStripMenuItem.Tag = "sendword";
            this.sendAFileToolStripMenuItem.Text = "Send a file";
            this.sendAFileToolStripMenuItem.Click += new System.EventHandler(this.ServerConexion);
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.recordsToolStripMenuItem.Tag = "getrecords";
            this.recordsToolStripMenuItem.Text = "Records";
            this.recordsToolStripMenuItem.Click += new System.EventHandler(this.ServerConexion);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.Location = new System.Drawing.Point(12, 36);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(698, 402);
            this.MainMenuPanel.TabIndex = 6;
            // 
            // RecordsPanel
            // 
            this.RecordsPanel.Controls.Add(this.label2);
            this.RecordsPanel.Controls.Add(this.tbRecords);
            this.RecordsPanel.Location = new System.Drawing.Point(12, 36);
            this.RecordsPanel.Name = "RecordsPanel";
            this.RecordsPanel.Size = new System.Drawing.Size(698, 402);
            this.RecordsPanel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "Records";
            // 
            // tbRecords
            // 
            this.tbRecords.BackColor = System.Drawing.Color.DarkTurquoise;
            this.tbRecords.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbRecords.ForeColor = System.Drawing.Color.White;
            this.tbRecords.Location = new System.Drawing.Point(247, 165);
            this.tbRecords.Multiline = true;
            this.tbRecords.Name = "tbRecords";
            this.tbRecords.Size = new System.Drawing.Size(195, 119);
            this.tbRecords.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.RecordsPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecords);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainMenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Welcome to HangMan";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.RecordsPanel.ResumeLayout(false);
            this.RecordsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnPlay;
        private Button btnAddWord;
        private Button btnRecords;
        private Button btnExit;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem addWordToolStripMenuItem;
        private ToolStripMenuItem sendAWordToolStripMenuItem;
        private ToolStripMenuItem sendAFileToolStripMenuItem;
        private ToolStripMenuItem recordsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem menuToolStripMenuItem;
        private Panel MainMenuPanel;
        private Panel RecordsPanel;
        private Label label2;
        private TextBox tbRecords;
    }
}