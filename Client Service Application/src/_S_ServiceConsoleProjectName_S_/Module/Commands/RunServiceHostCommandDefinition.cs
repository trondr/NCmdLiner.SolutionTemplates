using System;
using System.Reflection;
using System.ServiceModel;
using Castle.Facilities.WcfIntegration;
using Common.Logging;
using NCmdLiner.Attributes;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.Common.Services;
using _S_ServiceContractsProjectName_S_;

namespace _S_ServiceConsoleProjectName_S_.Module.Commands
{
    public class RunServiceHostCommandDefinition : CommandDefinition
    {
        private readonly IKeepAliveServiceFactory _keepAliveServiceFactory;
        private readonly DefaultServiceHostFactory _defaultServiceHostFactory;
        private readonly ILog _logger;
        private string _keepAliveFile;

        public RunServiceHostCommandDefinition(IKeepAliveServiceFactory keepAliveServiceFactory, DefaultServiceHostFactory defaultServiceHostFactory, ILog logger)
        {
            _keepAliveServiceFactory = keepAliveServiceFactory;
            _defaultServiceHostFactory = defaultServiceHostFactory;
            _logger = logger;
        }

        [Command(Description = "Run _S_ProductName_S_ Manager Host")]
        public int RunServiceHost()
        {
            _logger.Info("Starting Service Console...");
            var serviceHost = (DefaultServiceHost)(_defaultServiceHostFactory.CreateServiceHost(typeof(I_S_ShortProductName_S_Manager).AssemblyQualifiedName, new Uri[] { }));
            serviceHost.Faulted += ServiceHostFaulted;
            serviceHost.EndpointCreated += ServiceHostEndpointCreated;
            serviceHost.Closing += ServiceHostClosing;
            serviceHost.Closed += ServiceHostClosed;
            serviceHost.Opened += ServiceHostOpened;
            serviceHost.Opening += ServiceHostOpening;
            serviceHost.UnknownMessageReceived += ServiceHostUnknownMessageReceived;
            try
            {
                serviceHost.Open();
            }
            catch (AddressAccessDeniedException ex)
            {
                _logger.ErrorFormat("{0}. Tip: From a administrative command prompt run: netsh http add urlacl url=<your url> user=<your user or group>", ex.Message);
                return 1;
            }            
           _keepAliveFile = Assembly.GetEntryAssembly().Location + ".keepalive";
            _logger.InfoFormat("Press ESC, OR delete the keep alive file '{0}' to terminate _S_ProductName_S_ Service Console.", _keepAliveFile);
            using (var keepAliveService = _keepAliveServiceFactory.GetKeepAliveService(_keepAliveFile))
            {                
                keepAliveService.Activate();
                serviceHost.Close();                
            }             
            return 0;
        }

        void ServiceHostUnknownMessageReceived(object sender, System.ServiceModel.UnknownMessageReceivedEventArgs e)
        {
            _logger.WarnFormat("_S_ProductName_S_ Service host has received an unknown message: {0}", e.Message);
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
