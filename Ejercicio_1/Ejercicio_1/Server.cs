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

        private bool conexion = true;
        public void init()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ip), port);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(2);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                while (conexion)
                {
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
                        try
                        {
                            msg = sr.ReadLine();
                            switch (msg)
                            {
                                case "time":
                                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                                    sw.Flush();
                                    break;

                                case "date":
                                    sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy"));
                                    sw.Flush();
                                    break;

                                case "all":
                                    sw.WriteLine(DateTime.Now.ToString());
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
                                                conexion = false;
                                                sw.Flush();
                                                sClient.Close();
                                                s.Close();
                                            }
                                            else
                                            {
                                                sw.WriteLine("That password its incorrect");
                                                sw.Flush();
                                            }
                                        }
                                        catch (IOException)
                                        {
                                            conexion = false;
                                        }
                                    }
                                    break;

                                default:
                                    sw.WriteLine("Unrecognized command");
                                    sw.Flush();
                                    break;
                            }
                        }
                        catch (IOException e)
                        {
                            conexion = false;
                        }
                        Console.WriteLine("Client disconnected.\nConnection closed");
                    }
                    sClient.Close();
                }
            }
        }
    }
}
