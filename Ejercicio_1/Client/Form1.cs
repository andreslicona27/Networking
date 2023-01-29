using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Time":
                    lblInfo.Text += Petition("time");
                    break;

                case "Date":
                    lblInfo.Text += Petition("date");
                    break;

                case "Date and Time":
                    lblInfo.Text += Petition("all");
                    break;

                case "Close Server":
                    if (txtPassword.Text != null && txtPassword.Text.Length > 0)
                    {
                        lblInfo.Text += Petition("close " + txtPassword);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a password first", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }
        }

        const string IP_SERVER = "127.0.0.1";
        const int PORT = 12000;
        string msg;
        string userMsg;
        string serverResponse;
        public string Petition(string petition)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), PORT);
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ie);
            }
            catch (SocketException error)
            {
                MessageBox.Show(error.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (NetworkStream ns = new NetworkStream(server))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                msg = sr.ReadLine();
                while (true)
                {
                    userMsg = petition;
                    sw.WriteLine(userMsg);
                    sw.Flush();
                    msg = sr.ReadLine();
                }
            }
            server.Close();

            return msg;
        }

        private void btnChangeIP_Click(object sender, EventArgs e)
        {
            Form2 changeServer = new Form2();
            changeServer.ShowDialog();

        }
    }
}