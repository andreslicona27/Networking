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
        public bool conection = true;
        public Form2(string IP, int PORT)
        {
            InitializeComponent();
            lblIp.Text += IP.ToString();
            lblPort.Text += PORT.ToString();
        }

        public IPAddress ip;
        public IPAddress newIp;
        public int port;
        public int newPort;
        private void btnChange_Click(object sender, EventArgs e)
        {
            bool ipTry = IPAddress.TryParse(txtIp.Text, out newIp);
            if (ipTry)
            {
                ip = newIp;
            }
            else 
            {
                MessageBox.Show("That IP address is not valid", "IP Address Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conection = false;
            }

            bool portTry = int.TryParse(txtPort.Text, out newPort);
            if (txtPort.Text.Length == 5 && portTry)
            {
                port = newPort;
            }
            else
            {
                MessageBox.Show("That port is not valid", "Port Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conection = false;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
