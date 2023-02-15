using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Sockets;
using System.Net;
using System;

namespace Client
{
    public partial class Form1 : Form
    {
        string IP_SERVER = "192.168.20.100";
        int PORT = 5001;
        string userMsg;
        bool ipCorrect;
        bool portCorrect;
        string word;

        public Form1()
        {
            InitializeComponent();
            RecordsPanel.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenuPanel.Visible = true;
            RecordsPanel.Visible = false;
        }

        private void ServerConexion(object sender, EventArgs e)
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
                        userMsg = "getrecords";
                        sw.WriteLine(userMsg);
                        sw.Flush();

                        sr.ReadLine();

                        userMsg = ((Button)sender).Tag.ToString();
                        sw.WriteLine(userMsg);
                        sw.Flush();

                        switch (((Button)sender).Tag.ToString())
                        {
                            case "getword":
                                word = sr.ReadLine();
                                break;

                            case "sendword":
                                break;

                            case "getrecords":
                                MainMenuPanel.Visible = false;
                                RecordsPanel.Visible = true;
                                tbRecords.Text = sr.ReadLine();
                                break;

                            case "sendrecord":
                                break;

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
                MessageBox.Show("Error with the conection: " + error, "Conexion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}