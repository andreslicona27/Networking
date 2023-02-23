using Ejercicio_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

        protected override void OnStart(string[] args)
        {
            writeEvent("Running the service");
            Server s = new Server();
            Thread serviceThread = new Thread(s.init);
            if (s.weHaveConexion)
            {
                writeEvent($"You are connected at port: {s.Port}");
            }
            else
            {
                writeEvent($"You have an error: {s.message}");
            }


        }

        protected override void OnStop()
        {
            writeEvent("You stop the service");
        }
    }
}
