using Ejercicio_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Remoting.Channels;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

        }

        public void writeEvent(string mensaje)
        {
            string nombre = "My Time and Date Service";
            string logDestino = "Application";
            if (!EventLog.SourceExists(nombre))
            {
                EventLog.CreateEventSource(nombre, logDestino);
            }
            EventLog.WriteEntry(nombre, mensaje);
        }

        Server s = new Server();
        Thread serviceThread;
        protected override void OnStart(string[] args)
        {
            writeEvent("Running the service");
            serviceThread = new Thread(s.init);
            serviceThread.Start();
        }

        protected override void OnStop()
        {
            writeEvent("You stop the service");

            s.cerrarServicio();
        }
    }
}
