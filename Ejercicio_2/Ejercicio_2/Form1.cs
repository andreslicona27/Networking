using System;
using System.Net.Sockets;
using System.Net;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        string IP_SERVER = "192.168.20.100";
        int PORT = 5001;
        string msg;
        string userMsg;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            ChangeServer cs = new ChangeServer(IP_SERVER, PORT);
            if (cs.ShowDialog() == DialogResult.OK)
            {
                IP_SERVER = cs.ip.ToString();
                PORT = cs.port;
                tbInfo.Text = "Information: Server changed successfully";
            }
        }

        private void btn_Click(object sender, EventArgs e)
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
                    try
                    {
                        if (tbUser.Text != null && tbUser.Text.Length > 0)
                        {
                            userMsg = "user " + tbUser.Text.Trim();
                            sw.WriteLine(userMsg);
                            sw.Flush();

                            sr.ReadLine();

                            userMsg = ((Button)sender).Tag.ToString();
                            sw.WriteLine(userMsg);
                            sw.Flush();

                            while (sr.ReadLine() != null)
                            {
                                tbInfo.Text += sr.ReadLine() + "\r\n";
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please enter a user", "Missing User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                MessageBox.Show("Error with the server conection " + error.Message, "Socket Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE");
            try
            {
                if (!File.Exists(path + "\\Conection_Info.txt"))
                {
                    File.Create(path + "\\Conection_Info.txt");
                }

                using (StreamWriter sw = new StreamWriter(path + "\\Conection_Info.txt"))
                {
                    sw.WriteLine(IP_SERVER);
                    sw.WriteLine(PORT);
                    sw.WriteLine(tbUser.Text);
                }
            }
            catch (IOException)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE");
            if (File.Exists(path + "\\Conection_Info.txt"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path + "\\Conection_Info.txt"))
                    {
                        IP_SERVER = sr.ReadLine();
                        PORT = int.Parse(sr.ReadLine());
                        tbUser.Text = sr.ReadLine();
                    }
                }
                catch (IOException)
                {

                }
            }

        }
    }
}