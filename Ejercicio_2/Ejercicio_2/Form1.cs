using System;
using System.Net.Sockets;
using System.Net;

namespace Ejercicio_2
{
    public partial class Form1 : Form
    {
        string IP_SERVER = "192.168.20.100";
        int PORT = 5001;
        string userMsg;
        bool ipCorrect;
        bool portCorrect;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            ChangeServer cs = new ChangeServer(IP_SERVER, PORT);
            if (cs.ShowDialog() == DialogResult.OK)
            {
                if (cs.ip != null && cs.port != null)
                {
                    ipCorrect = IPAddress.TryParse(cs.ip.ToString(), out IPAddress ip);
                    if (ipCorrect)
                    {
                        IP_SERVER = ip.ToString();
                    }
                    else
                    {
                        IP_SERVER = "192.168.20.100";
                    }
                    if (cs.port < IPEndPoint.MaxPort)
                    {
                        PORT = cs.port;
                    }
                    else
                    {
                        PORT = 5001;
                    }
                    tbInfo.Text = "Information: Server changed successfully";
                }
                else
                {
                    MessageBox.Show("Some informacion is missing", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string path = Environment.GetEnvironmentVariable("USERPROFILE");
                try
                {
                  

                    using (StreamWriter sw = new StreamWriter(path + "\\Conection_Info.txt"))
                    {
                        sw.WriteLine(IP_SERVER);
                        sw.WriteLine(PORT);
                        sw.WriteLine(tbUser.Text);
                    }
                }
                catch (IOException error)
                {
                    Console.WriteLine($"Error {error.Message}");
                }
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

                            if (((Button)sender).Tag.ToString().Equals("add"))
                            {
                                tbInfo.Text = sr.ReadLine();

                            }
                            else
                            {
                                tbInfo.Text = "";
                                while (sr.ReadLine() != null)
                                {
                                    tbInfo.Text += sr.ReadLine() + "\r\n";
                                }
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



        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE");
            if (File.Exists(path + "\\Conection_Info.txt"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path + "\\Conection_Info.txt"))
                    {
                        ipCorrect = IPAddress.TryParse(sr.ReadLine(), out IPAddress ip);
                        portCorrect = int.TryParse(sr.ReadLine(), out int port);
                        if (ipCorrect)
                        {
                            IP_SERVER = ip.ToString();
                        }
                        else
                        {
                            IP_SERVER = "192.168.20.100";
                        }
                        if (portCorrect && port < IPEndPoint.MaxPort)
                        {
                            PORT = port;
                        }
                        else
                        {
                            PORT = 5001;
                        }
                        tbUser.Text = sr.ReadLine();
                    }
                }
                catch (IOException error)
                {
                    Console.WriteLine($"Error {error.Message}");
                }
            }

        }
    }
}