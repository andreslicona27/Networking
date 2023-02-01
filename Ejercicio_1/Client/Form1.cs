using System.Net.Sockets;
using System.Net;
using System.ComponentModel.Design;

namespace Client
{
    public partial class Form1 : Form
    {

        string IP_SERVER;
        int PORT;
        string msg;
        string userMsg;

        public Form1()
        {
            InitializeComponent();
            IP_SERVER = "127.0.0.1";
            PORT = 12000;
        }

        private void button_Click(object sender, EventArgs e)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), PORT);
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
            catch (SocketException error)
            {
                MessageBox.Show("Error with the server conection" + error.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnChangeIP_Click(object sender, EventArgs e)
        {
            Form2 changeServer = new Form2(IP_SERVER, PORT);
            if (changeServer.ShowDialog() == DialogResult.OK)
            {
                if (changeServer.conection)
                {
                    IP_SERVER = changeServer.ip.ToString();
                    PORT = changeServer.port;
                    lblInfo.Text = "Information: Server changed successfully";
                }
                else
                {
                    lblInfo.Text = "Information: There was an error";
                }
            }



        }

    }
}