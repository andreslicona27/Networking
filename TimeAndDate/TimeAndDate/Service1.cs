using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndDate
{
    public partial class TimeAndDate : ServiceBase
    {
        public TimeAndDate()
        {
            InitializeComponent();
        }
        public void writeEvent(string mensaje)
        {
            string nombre = "TimeAdnDate";
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
            writeEvent(string.Format($"SimpleService running about {t} seconds"));
            t += 10;
        }
        protected override void OnStart(string[] args)
        {
            writeEvent("Running OnStart");
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 10000; // cada 10 segundos
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerTick);
            timer.Start();

        }

        protected override void OnStop()
        {
            writeEvent("Deteniendo servicio");
            t = 0;
        }

        //Se ejecuta cuando pausa el servicio
        protected override void OnPause()
        {
            writeEvent("Servicio en Pausa");
        }
        //Se ejecuta cuando continua tras la pausa el servicio
        protected override void OnContinue()
        {
            writeEvent("Continuando servicio");
        }

    }
}
