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
        private readonly DefaultServiceHostFactory _defaultServiceHostFactory;
        private readonly ILog _logger = LogManager.GetLogger<_S_ShortProductName_S_WindowsService>();
        public DefaultServiceHost ServiceHost = null;

        public _S_ShortProductName_S_WindowsService(DefaultServiceHostFactory defaultServiceHostFactory)
        {
            _defaultServiceHostFactory = defaultServiceHostFactory;
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
                ServiceHost = (DefaultServiceHost)(_defaultServiceHostFactory.CreateServiceHost(typeof(I_S_ShortProductName_S_Manager).AssemblyQualifiedName, new Uri[] { }));
                ServiceHost.Faulted += ServiceHostFaulted;
                ServiceHost.EndpointCreated += ServiceHostEndpointCreated;
                ServiceHost.Closing += ServiceHostClosing;
                ServiceHost.Closed += ServiceHostClosed;
                ServiceHost.Opened += ServiceHostOpened;
                ServiceHost.Opening += ServiceHostOpening;

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

        void ServiceHostOpening(object sender, EventArgs e)
        {
            _logger.InfoFormat("_S_ProductName_S_ Service host is starting...");
        }

        void ServiceHostOpened(object sender, EventArgs e)
        {
            _logger.InfoFormat("_S_ProductName_S_ Service host has been started.");
        }

        void ServiceHostClosed(object sender, EventArgs e)
        {
            _logger.InfoFormat("_S_ProductName_S_ Service host has been closed.");
        }

        void ServiceHostClosing(object sender, EventArgs e)
        {
            _logger.InfoFormat("_S_ProductName_S_ Service host is closing.");
        }

        void ServiceHostEndpointCreated(object sender, EndpointCreatedArgs e)
        {
            _logger.Info("End point has been created: " + e.Endpoint);
        }

        void ServiceHostFaulted(object sender, EventArgs e)
        {
            _logger.ErrorFormat("_S_ProductName_S_ Service host faulted. Sender: {0}. EventArgs: {1}", sender, e);
        }
    }
}
