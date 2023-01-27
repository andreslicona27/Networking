using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    internal class Server
    {
        private string ip = "127.0.0.1";
        public string Ip
        {
            set
            {
                ip = value;
            }
            get
            {
                return ip;
            }
        }

        private int port = 12000;
        public int Port
        {
            set
            {
                port = value;
            }
            get
            {
                return port;
            }
        }


        public void init()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ip), port);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(2);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                Socket sClient = s.Accept();
                IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
                Console.WriteLine("Client connected: {0} at port {1}", ieClient.Address,
               ieClient.Port);
                using (NetworkStream ns = new NetworkStream(sClient))
                using (StreamReader sr = new StreamReader(ns))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string welcome = "Welcome to the ultimate server, thats powerfull enough to give the time, the date an even the combination of both";
                    sw.WriteLine(welcome);
                    sw.Flush();
                    string msg = "";
                    while (msg != null)
                    {
                        try
                        {
                            msg = sr.ReadLine();
                            if (msg != null)
                            {
                                switch (msg)
                                {
                                    case "time":
                                        string time = DateTime.Now.ToString("HH:mm:ss");
                                        sw.WriteLine(time);
                                        msg = null;
                                        sw.Flush();
                                        break;

                                    case "date":
                                        string date = DateTime.Now.ToString("dd-MM-yyyy");
                                        sw.WriteLine(date);
                                        msg = null;
                                        sw.Flush();
                                        break;

                                    case "all":
                                        string all = DateTime.Now.ToString();
                                        sw.WriteLine(all);
                                        msg = null;
                                        sw.Flush();
                                        break;

                                    case String closeMsg when closeMsg.StartsWith("close"):
                                        string path = Environment.GetEnvironmentVariable("PROGRAMDATA");
                                        string clientPassword = "";
                                        using (StreamReader srPassword = new StreamReader(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\password.txt"))
                                        {
                                            try
                                            {
                                                if (closeMsg.Length > 5)
                                                {
                                                    clientPassword = closeMsg.Substring(5).Trim();
                                                }

                                                string password = srPassword.ReadToEnd();
                                                if (password.Equals(clientPassword))
                                                {
                                                    sw.WriteLine("Server closed successfully");
                                                    msg = null;
                                                    sw.Flush();
                                                    sClient.Close();
                                                    s.Close();
                                                }
                                                else
                                                {
                                                    sw.WriteLine("That password its incorrect");
                                                    msg = null;
                                                    sw.Flush();
                                                }
                                            }
                                            catch (IOException)
                                            {
                                                msg = null;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        catch (IOException e)
                        {
                            msg = null;
                        }
                    }
                    Console.WriteLine("Client disconnected.\nConnection closed");
                }
                sClient.Close();
            }


        }
    }
}
