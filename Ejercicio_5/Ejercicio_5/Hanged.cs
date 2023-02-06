﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.IO;

namespace Ejercicio_5
{
    internal class Hanged
    {
        string IP_SERVER = "127.0.0.1";
        int PORT = 12000;
        string[] words;
        bool conexion = true;
        Random rand = new Random();
        string pathRecord = Environment.GetEnvironmentVariable("USERPROFILE") + "\\records.txt";

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
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].ToUpper();
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
                        string welcome = "Welcome to the best game of hanged you will find";
                        sw.WriteLine(welcome);
                        sw.Flush();
                        string msg = "";
                        try
                        {
                            msg = sr.ReadLine();
                            switch (msg)
                            {
                                case "getword":
                                    getWords();
                                    int num = rand.Next(1, words.Length);
                                    sw.WriteLine(words[num]);
                                    sw.Flush();
                                    break;

                                case String newWordOption when newWordOption.StartsWith("sendword"):
                                    string newWord = "";
                                    try
                                    {
                                        using (StreamWriter swWord = new StreamWriter(Environment.GetEnvironmentVariable("USERPROFILE") + "\\palabras.txt", true))
                                        {
                                            if (newWordOption.Length > 9)
                                            {
                                                newWord = newWordOption.Substring(9);
                                                swWord.WriteLine("," + newWord);
                                                sw.WriteLine("OK");
                                                sw.Flush();
                                                getWords();

                                            }
                                            else
                                            {
                                                sw.WriteLine("ERROR");
                                                sw.Flush();
                                            }
                                        }
                                    }
                                    catch (IOException)
                                    {
                                        sClient.Close();
                                    }
                                    break;

                                case "getrecords":
                                    bool hasRecords = true;
                                    try
                                    {
                                        if (!File.Exists(pathRecord))
                                        {
                                            File.Create(pathRecord);
                                            hasRecords = false;
                                        }
                                        else
                                        {
                                            FileInfo f = new FileInfo(pathRecord);
                                            if (f.Length < 0)
                                            {
                                                hasRecords = false;
                                            }
                                        }

                                        if (hasRecords)
                                        {
                                            string message = "";
                                            using (StreamReader srRecords = new StreamReader(pathRecord))
                                            {
                                                //if (srRecords != null)
                                                //{
                                                message = srRecords.ReadToEnd();
                                                sw.WriteLine(message);
                                                sw.Flush();
                                                //}
                                            }
                                        }
                                        else
                                        {
                                            sw.WriteLine("No records to show yet");
                                            sw.Flush();
                                        }
                                    }
                                    catch (IOException)
                                    {
                                        conexion = false;
                                    }

                                    break;

                                case String record when record.StartsWith("sendrecord"):
                                    string aux = "";
                                    bool newRecordObteined = false;
                                    try
                                    {
                                        if (!File.Exists(pathRecord))
                                        {
                                            File.Create(pathRecord);
                                        }

                                        using (StreamWriter swRecord = new StreamWriter(pathRecord))
                                        {
                                            if (record.Length > 11)
                                            {
                                                record = record.Substring(10);
                                                string time = record.Substring(3).Trim();
                                                using (StreamReader srSetRecord = new StreamReader(pathRecord))
                                                {
                                                    aux = srSetRecord.ReadToEnd();
                                                }
                                                string[] records = aux.Split("\r\n");

                                                for (int i = 0; i < records.Length; i++)
                                                {
                                                    if (int.Parse(records[i].Substring(3).Trim()) < int.Parse(time))
                                                    {
                                                        records[i] = record;
                                                        newRecordObteined = true;
                                                    }
                                                }

                                                using (StreamWriter swSetRecord = new StreamWriter(pathRecord))
                                                {
                                                    foreach (string r in records)
                                                    {
                                                        swSetRecord.WriteLine(r + "\r\n");
                                                    }
                                                }

                                            }

                                            if (newRecordObteined)
                                            {
                                                sw.WriteLine("ACCEPT");
                                                sw.Flush();
                                            }
                                            else
                                            {
                                                sw.WriteLine("REJECT");
                                                sw.Flush();
                                            }
                                        }
                                    }
                                    catch (IOException)
                                    {
                                        sClient.Close();
                                    }

                                    break;

                                case String closeMsg when closeMsg.StartsWith("closeserver"):
                                    using (StreamReader srPassword = new StreamReader(Environment.GetEnvironmentVariable("PROGRAMDATA") + "\\password.txt"))
                                    {
                                        try
                                        {
                                            string clientPassword = "";
                                            if (closeMsg.Length > 13)
                                            {
                                                clientPassword = closeMsg.Substring(12).Trim();
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
