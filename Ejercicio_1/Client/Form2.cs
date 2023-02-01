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
        public Form2(string IP, int PORT)
        {
            InitializeComponent();
            lblIp.Text += IP.ToString();
            lblPort.Text += PORT.ToString();
            btnChange.Visible = false;
        }

        public IPAddress ip;
        public IPAddress newIp;
        public int port;
        public int newPort;
        private void btnChange_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ip = newIp;
            port = newPort;
            Close();
        }

        private void txtIp_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender) == txtIp)
            {
                bool ipTry = IPAddress.TryParse(txtIp.Text, out newIp);
                if (!ipTry)
                {
                    txtIp.BackColor = Color.Red;
                }
                else
                {
                    txtIp.BackColor = Color.LightGreen;
                }

            }
            else if (((TextBox)sender) == txtPort)
            {
                bool portTry = int.TryParse(txtPort.Text, out newPort);
                if (!portTry || txtPort.Text.Length != 5)
                {
                    txtPort.BackColor = Color.Red;
                }
                else
                {
                    txtPort.BackColor = Color.LightGreen;
                }
            }

            if (txtIp.BackColor == Color.Red || txtPort.BackColor == Color.Red)
            {
                btnChange.Visible = false;
            }
            else
            {
                btnChange.Visible = true;
            }
        }
    }
}
