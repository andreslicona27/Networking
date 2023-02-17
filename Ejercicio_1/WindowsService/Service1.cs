using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
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
        
        private int t = 0;
        public void TimerTick(object sender, System.Timers.ElapsedEventArgs args)
        {
            writeEvent(string.Format($"Time and Date Service running about {t} seconds"));
            t += 10;
        }

        protected override void OnStart(string[] args)
        {
            writeEvent("Running OnStart");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000; 
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerTick);
            timer.Start();

        }

        protected override void OnStop()
        {
        }
    }
}
