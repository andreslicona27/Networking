using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Collections;
using System.Xml.Linq;
using System.Numerics;

namespace Ejercicio_6
{
    internal class Server
    {
        private static readonly object l = new object();
        private readonly Random rand = new Random();
        public int port = 12000;

        List<User> users = new List<User>();
        List<int> randomNumbers = new List<int>();

        public bool gameOn = true;
        public bool serverRunning = true;
        public int numberToHit;
        public User? winner = null;
        public int thereIsAWinner = 0;

        public void Init()
        {
            bool tryConexion = false;
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, port);
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
                s.Listen(20);
                Console.WriteLine($"Server listening at port:{ie.Port}");
                while (gameOn)
                {
                    ResetTheGame();
                    Thread time = new Thread(TimeForTheGame);
                    time.IsBackground = true;
                    time.Start();

                    while (serverRunning)
                    {
                        try
                        {
                            Socket client = s.Accept();
                            Thread thread = new Thread(PlayerFunction);
                            thread.IsBackground = true;
                            thread.Start(client);
                        }
                        catch (SocketException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    // To disconnect all the clients after the match have finish
                    lock (l)
                    {
                        users.ForEach(u => { u.Socket.Close(); });
                    }
                }
            }
        }
        public void PlayerFunction(object socketClient)
        {
            bool userAlone = true;
            bool maxUsers = false;

            User player = new User();
            Socket playerSocket = (Socket)socketClient;
            IPEndPoint iePlayer = (IPEndPoint)playerSocket.RemoteEndPoint;
            Console.WriteLine("Client connected: {0} at port {1}", iePlayer.Address, iePlayer.Port);

            using (NetworkStream ns = new NetworkStream(playerSocket))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                lock (l)
                {
                    player.Ipaddress = iePlayer.Address;
                    player.Socket = playerSocket;
                    player.Sw = sw;
                    player.Connected = true;

                    if (randomNumbers.Count != 0)
                    {
                        player.Number = randomNumbers[0];
                        randomNumbers.RemoveAt(0);
                        users.Add(player);

                        maxUsers = false;
                    }
                    else
                    {
                        player.Socket.Close();
                        maxUsers = true;
                    }
                }

                if (maxUsers)
                {
                    PrintMsgToAll("The user limit has already been reached");
                }
                else
                {
                    while (player.Connected)
                    {
                        if (userAlone)
                        {
                            lock (l)
                            {
                                if (users.Count < 2)
                                {
                                    player.Sw.WriteLine("Waiting for more users to join");
                                    player.Sw.Flush();
                                    userAlone = false;
                                }
                            }
                        }

                        lock (l)
                        {
                            switch (thereIsAWinner)
                            {
                                case 1:
                                    string youWin = $"Congratulations! You win with the number {player.Number}";
                                    string youLose = $" What a pity, you lost! The winner number was {winner?.Number} and {winner?.Ipaddress.ToString()} was the user with that number. Your number was {player.Number}";
                                    PrintMsg(player.Number == winner.Number ? youWin : youLose, player.Sw);
                                    player.Connected = false;
                                    break;
                                case 2:
                                    PrintMsg($"Nobody wins this time. The winner number was {winner?.Number} and yours was {player.Number}", player.Sw);
                                    player.Connected = false;
                                    break;
                            }
                        }
                    }
                }
            }
            player.Socket.Close();

        }

        public void TimeForTheGame()
        {
            bool startTheGame = true; // decides when the game starts
            bool weArePlaying = false; // In case the game start we set the timer to run
            int seconds = 20; // Initial starting time 
            numberToHit = new Random().Next(1, 20); // Number that players need to get to win 

            while (startTheGame)
            {
                Thread.Sleep(1000);

                lock (l)
                {
                    if (users.Count >= 2)
                    {
                        weArePlaying = true;
                    }
                    // The timer for the game starts
                    if (weArePlaying)
                    {
                        seconds--;
                        PrintMsgToAll(TimeSpan.FromSeconds(seconds).ToString("ss"));
                    }

                    //if (seconds >= timeToReach)}
                    if (seconds == 0)
                    {
                        // we see if a user get lucky with the number
                        users.ForEach(user =>
                        {
                            if (user.Number == numberToHit)
                            {
                                winner = user;
                            }
                        });

                        if (winner != null)
                        {
                            thereIsAWinner = 1;
                        }
                        else
                        {
                            thereIsAWinner = 2;
                            winner = new User();
                            winner.Number = numberToHit;
                        }
                        startTheGame = false;
                        serverRunning = false;
                    }
                }
            }
        }

        public void PrintMsg(string message, StreamWriter sw)
        {
            try
            {
                sw.WriteLine(message);
                sw.Flush();
            }
            catch (IOException e)
            {
                Console.WriteLine($"The user has disconnected: {e.Message}");
            }
        }

        public void PrintMsgToAll(string message)
        {
            lock (l)
            {
                foreach (User user in users)
                {
                    try
                    {
                        user.Sw.WriteLine(message);
                        user.Sw.Flush();

                    }
                    catch (IOException e)
                    {
                        Console.WriteLine($"The user has disconnected");
                    }
                }
            }
        }

        public void ResetTheGame()
        {
            lock (l)
            {
                users.Clear();
                randomNumbers.Clear();

                // We refill the randomNumbers list
                for (int i = 1; i < 21; i++)
                {
                    randomNumbers.Add(i);
                }

                // Now we rearrange the numbers in random form
                for (int i = 0; i < randomNumbers.Count; i++)
                {
                    // Generate a random index between 0 and the number of elements in the list
                    int j = rand.Next(randomNumbers.Count);

                    // Swap the elements at position i and j
                    int aux = randomNumbers[i];
                    randomNumbers[i] = randomNumbers[j];
                    randomNumbers[j] = aux;
                }

                numberToHit = 0;
                thereIsAWinner = 0;
                winner = null;
                serverRunning = true;
            }
        }
    }


}
