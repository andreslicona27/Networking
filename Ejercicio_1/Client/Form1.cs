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
                    lblInfo.Text = "Information: " + Petition("time");
                    break;

                case "Date":
                    lblInfo.Text = "Information: " + Petition("date");
                    break;

                case "Date and Time":
                    lblInfo.Text = "Information: " + Petition("all");
                    break;

                case "Close Server":
                    if (txtPassword.Text != null && txtPassword.Text.Length > 0)
                    {
                        lblInfo.Text = "Information: " + Petition("close " + txtPassword.Text);
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
                try
                {
                    userMsg = petition;
                    sw.WriteLine(userMsg);
                    sw.Flush();
                    msg = sr.ReadLine();
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error with the server\n" + e.ToString(), "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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