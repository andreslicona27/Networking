using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;

namespace Ejercicio_3
{
    internal class Server
    {
        public string ip = "192.168.20.11";
        //public string ip = "192.168.56.1";
        public int port = 12000;
        Dictionary<string, StreamWriter> clients = new Dictionary<string, StreamWriter>();
        private static readonly object l = new object();
        public void init()
        {
            bool tryConexion = false;
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ip), port);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                do
                {
                    try
                    {
                        s.Bind(ie);
                        tryConexion = true;
                    }
                    catch (SocketException error)
                    {
                        Console.WriteLine($"Erorr: {error.Message}");
                        ie.Port++;
                    }
                } while (!tryConexion);
                s.Listen(10);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                while (true)
                {
                    Socket sClient = s.Accept();
                    Thread thread = new Thread(threadClient);
                    thread.Start(sClient);

                }
            }
        }

        public void threadClient(object socket)
        {
            Socket client = (Socket)socket;
            IPEndPoint ieClient = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Client connected: {0} at port {1}", ieClient.Address, ieClient.Port);
            using (NetworkStream ns = new NetworkStream(client))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                string msgUser = "";
                string user;
                string list = "";
                try
                {
                    msgUser = sr.ReadLine();
                    if (msgUser != null && msgUser.StartsWith("user "))
                    {
                        user = string.Format("{0}@{1}", msgUser.Substring(5), ieClient.Address);
                        addClient(user, sw);
                        printMsg($"{user} has connected", user);

                        sw.WriteLine("Connected");
                        sw.Flush();

                        while (msgUser != null)
                        {
                            msgUser = sr.ReadLine();
                            switch (msgUser)
                            {
                                case string msg when msg.Contains("#exit"):
                                    lock (l)
                                    {
                                        clients.Remove(user);
                                    }
                                    msgUser = null;
                                    break;

                                case string msg when msg.Contains("#list"):
                                    lock (l)
                                    {
                                        foreach (string c in clients.Keys)
                                        {
                                            list += c + "\r\n";
                                        }
                                    }
                                    sw.Write(list);
                                    sw.Flush();
                                    list = "";
                                    break;

                                default:
                                    printMsg($"{user} {msgUser}", user);
                                    break;
                            }
                        }
                        lock (l)
                        {
                            clients.Remove(user);
                        }
                        printMsg($"{user} has desconnected", user);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error {e.Message}");
                }
                Console.WriteLine("Client disconnected.\nConnection closed");
            }
            client.Close();

        }

        public void addClient(string user, StreamWriter sw)
        {
            bool added = false;
            while (!added)
            {
                lock (l)
                {
                    if (!added)
                    {
                        clients.Add(user, sw);
                        added = true;
                    }
                }
            }
        }

        public void printMsg(string message, string userSended)
        {
            lock (l)
            {
                foreach (KeyValuePair<string, StreamWriter> pair in clients)
                {
                    if (pair.Key != userSended && pair.Value != null)
                    {
                        pair.Value.WriteLine(message);
                        pair.Value.Flush();
                    }
                }
            }

        }

    }
}
