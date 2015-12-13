using System;
using System.ServiceModel;
using System.ServiceProcess;
using Castle.Facilities.WcfIntegration;
using Common.Logging;
using _S_ServiceContractsProjectName_S_;

namespace _S_ServiceProjectName_S_.Module
{
    partial class _S_ShortProductName_S_WindowsService : ServiceBase
    {
        private readonly ILog _logger = LogManager.GetLogger<_S_ShortProductName_S_WindowsService>();
        public ServiceHost ServiceHost = null;

        public _S_ShortProductName_S_WindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
             try
            {
                base.OnStart(args);                
                _logger.Info("Starting _S_ShortProductName_S_ service...");
                if (this.ServiceHost != null)
                {
                    this.ServiceHost.Close();
                }
                _logger.Info("Creating a ServiceHost for the _S_ShortProductName_S_Manager type and provide the base address.");
                ServiceHost = (DefaultServiceHost)(new DefaultServiceHostFactory().CreateServiceHost(typeof(I_S_ShortProductName_S_Manager).AssemblyQualifiedName, new Uri[] { }));
               _logger.Info("Service host has been created");

                _logger.Info("Opening the ServiceHost to create listeners and start listening for messages.");
                ServiceHost.Open();
               _logger.Info("_S_ShortProductName_S_ service has been started.");
            }
            catch (Exception ex)
            {
                _logger.Error("Failed to start _S_ShortProductName_S_ service. " + ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            base.OnStop();            
            _logger.Info("Stopping _S_ShortProductName_S_ service...");
            if (this.ServiceHost != null)
            {
                this.ServiceHost.Close();
                this.ServiceHost = null;
            }
           _logger.Info("_S_ShortProductName_S_ service has been stopped.");
        }
    }
}
