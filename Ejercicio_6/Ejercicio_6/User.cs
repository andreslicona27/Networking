using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_6
{
    internal class User
    {
        // PROPERTIES
        private IPAddress ipaddress;
        public IPAddress Ipaddress
        {
            set
            {
                ipaddress = value;
            }
            get
            {
                return ipaddress;
            }
        }
        private Socket socket;
        public Socket Socket
        {
            set
            {
                socket = value;
            }
            get
            {
                return socket;
            }
        }
        private StreamWriter sw;
        public StreamWriter Sw
        {
            set
            {
                sw = value;
            }
            get
            {
                return sw;
            }
        }
        private int number;
        public int Number
        {
            set
            {
                number = value;
            }
            get
            {
                return number;
            }
        }
        private bool connected;
        public bool Connected
        {
            set
            {
                connected = value;
            }
            get
            {
                return connected;
            }
        }

        public User()
        {
            this.ipaddress = null;
            this.socket = null;
            this.sw = null;
            this.number = 0;
            this.connected = false;
        }
        public User(IPAddress ipadress, Socket s, StreamWriter sw, int num, bool connected)
        {
            this.ipaddress = ipadress;
            this.socket = s;
            this.sw = sw;
            this.number = num;
            this.connected= connected;
        }
       
    }
}
