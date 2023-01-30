using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class Form1 : Form
    {

        const string IP_SERVER = "127.0.0.1";
        const int PORT = 12000;
        string msg;
        string userMsg;
        IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), PORT);

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ie);
                using (NetworkStream ns = new NetworkStream(server))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    msg = sr.ReadLine();
                    try
                    {
                        if (((Button)sender).Text.Equals("Close Server"))
                        {
                            if (txtPassword.Text != null && txtPassword.Text.Length > 0)
                            {
                                userMsg = ((Button)sender).Tag.ToString() + txtPassword.Text;
                            }
                            else
                            {
                                MessageBox.Show("Please enter a password first", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            userMsg = ((Button)sender).Tag.ToString();
                        }
                        sw.WriteLine(userMsg);
                        sw.Flush();
                        lblInfo.Text = "Information: " + sr.ReadLine();
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error with the server", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                server.Close();
            }
            catch (SocketException)
            {
                MessageBox.Show("Error with the server conection", "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnChangeIP_Click(object sender, EventArgs e)
        {
            Form2 changeServer = new Form2(ie.Address, ie.Port);
            if (changeServer.ShowDialog() == DialogResult.OK)
            {
                ie.Address = IPAddress.Parse(changeServer.ip);
                ie.Port = int.Parse(changeServer.port);
            }
        }

    }
}