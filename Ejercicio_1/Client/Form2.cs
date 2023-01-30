using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2(IPAddress IP, int PORT)
        {
            InitializeComponent();
            lblIp.Text += IP.ToString();
            lblPort.Text += PORT.ToString();
        }

        public string ip;
        public string port;
        private void btnChange_Click(object sender, EventArgs e)
        {
            ip = txtIp.Text;
            port = txtPort.Text;
            DialogResult = DialogResult.OK;
            Close();            
        }
    }
}
