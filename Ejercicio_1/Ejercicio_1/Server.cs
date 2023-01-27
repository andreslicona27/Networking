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
        private string ip;
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
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(10);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                Socket sClient = s.Accept();
                IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
                Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address,
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
                                switch(msg)
                                {
                                    case "Time":
                                        string time = DateTime.Now.ToString("HH:mm:ss");
                                        sw.WriteLine(time);
                                        sw.Flush();
                                        break;

                                    case "Date":
                                        string date = DateTime.Now.ToString("dd-MM-yyyy");
                                        sw.WriteLine(date);
                                        sw.Flush();
                                        break;

                                    case "All":
                                        string all = DateTime.Now.ToString();
                                        sw.WriteLine(all);
                                        sw.Flush();
                                        break;

                                    case String closeMsg when closeMsg.StartsWith("close"):
                                        break;
                                }
                                Console.WriteLine(msg);
                                sw.WriteLine(msg);
                                sw.Flush();
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
