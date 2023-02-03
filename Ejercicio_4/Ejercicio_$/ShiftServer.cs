using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio__
{
    internal class ShiftServer
    {
        public void init()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp))
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
                    string welcome = "Welcome to The Echo-Logic, Odd, Desiderable," +
                    "Incredible, and Javaless Echo Server(T.E.L.O.D.I.J.E. Server)";
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
