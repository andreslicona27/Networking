using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace Ejercicio_5
{
    internal class Hanged
    {
        string IP_SERVER = "192.168.20.100";
        int PORT = 5001;
        string[] words;
        bool conexion = true;
        Random rand = new Random();

        public void getWords()
        {
            try
            {
                string wordsChain = "";
                using (StreamReader sr = new StreamReader(Environment.GetEnvironmentVariable("USERPROFILE") + "\\palabras.txt"))
                {
                    wordsChain = sr.ReadToEnd();
                }

                words = wordsChain.Split(",");
                foreach (string word in words)
                {
                    word.ToUpper();
                }
            }
            catch (NullReferenceException)
            {

            }
        }
        public void init()
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(IP_SERVER), PORT);
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
                                case "getword":
                                    int num = rand.Next(1, words.Length);
                                    sw.WriteLine(words[num]);
                                    sw.Flush();
                                    break;

                                case String newWordOption when newWordOption.StartsWith("sendword"):
                                    string newWord = "";
                                    using (StreamWriter swWord = new StreamWriter(Environment.GetEnvironmentVariable("USERPROFILE") + "\\palabras", true))
                                    {
                                        try
                                        {
                                            if (newWordOption.Length > 9)
                                            {
                                                newWord = newWordOption.Substring(9);
                                                swWord.WriteLine("," + newWord);
                                                getWords();
                                            }
                                        }
                                        catch (IOException)
                                        {
                                        }
                                    }
                                    sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy"));
                                    sw.Flush();
                                    break;

                                case "getrecords":
                                    sw.WriteLine(DateTime.Now.ToString());
                                    sw.Flush();
                                    break;

                                case String closeMsg when closeMsg.StartsWith("closeserver"):
                                    string passwordPath = Environment.GetEnvironmentVariable("PROGRAMDATA");
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
