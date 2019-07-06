using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.Owin.Hosting;
using Soardibot;

namespace SoardiBotService
{
    public partial class SoardiBotService : ServiceBase
    {
        private IDisposable _soardiBotServer;
        private ILog _log;

        public SoardiBotService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                string serviceHost = ConfigurationManager.AppSettings["ServiceHost"] ?? "localhost";
                string servicePort = ConfigurationManager.AppSettings["ServicePort"] ?? "9090";

                var assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                XmlConfigurator.Configure(new FileInfo(Path.Combine(assemblyFolder, "log.config")));

                _log = LogManager.GetLogger(GetType());
                _soardiBotServer = WebApp.Start<SoardiBotStart>(url: $"http://{serviceHost}:{servicePort}/");
                _log.Info("SoardiBot server started");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                Stop();
            }
        }

        protected override void OnStop()
        {
            _soardiBotServer.Dispose();
        }
    }
}
