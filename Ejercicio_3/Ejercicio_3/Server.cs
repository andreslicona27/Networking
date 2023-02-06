using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ejercicio_3
{
    internal class Server
    {
        public string ip = "192.168.20.11";
        public int port = 12000;
        ArrayList clients = new ArrayList();
        public void init()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ip), port);
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                s.Bind(ie);
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
                clients.Add(sw);
                try
                {
                    msgUser = sr.ReadLine();
                    if (msgUser.StartsWith("user"))
                    {
                        string user = string.Format("{0}@{1}", msgUser.Substring(5), ieClient.Address);
                        printMsg(user + " has connected");
                        while (msgUser != null && !msgUser.Contains("#exit"))
                        {
                            msgUser = sr.ReadLine();
                            printMsg(user + " " + msgUser);
                        }
                        printMsg(user + " has desconnected");
                        clients.Remove(sw);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error " + e.Message);
                }
                Console.WriteLine("Client disconnected.\nConnection closed");
            }
            client.Close();

        }

        public void printMsg(string message)
        {
            foreach (StreamWriter client in clients)
            {
                if (client != null)
                {
                    client.WriteLine(message);
                    client.Flush();
                }
            }
        }
    }
}
