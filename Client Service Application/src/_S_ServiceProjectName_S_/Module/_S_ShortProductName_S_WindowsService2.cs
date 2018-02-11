using System;
using Castle.Facilities.WcfIntegration;
using Common.Logging;
using _S_ServiceContractsProjectName_S_;

namespace _S_ServiceProjectName_S_.Module
{
    public class _S_ShortProductName_S_WindowsService2 : I_S_ShortProductName_S_WindowsService2
    {
        private readonly DefaultServiceHostFactory _defaultServiceHostFactory;
        private readonly ILog _logger;
        public DefaultServiceHost ServiceHost = null;

        public _S_ShortProductName_S_WindowsService2(DefaultServiceHostFactory defaultServiceHostFactory, ILog logger)
        {
            _defaultServiceHostFactory = defaultServiceHostFactory;
            _logger = logger;
        }

        public void Start()
        {
            try
            {
                _logger.Info("Starting _S_ShortProductName_S_ service...");
                ServiceHost?.Close();
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

        public void Stop()
        {
            _logger.Info("Stopping _S_ShortProductName_S_ service...");
            ServiceHost?.Close();
            ServiceHost = null;            
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