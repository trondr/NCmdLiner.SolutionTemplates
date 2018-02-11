using System.ServiceProcess;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using _S_ServiceContractsProjectName_S_;
using _S_ServiceLibraryProjectName_S_.Module;
using _S_ServiceProjectName_S_.Infrastructure.ContainerExtensions;

namespace _S_ServiceProjectName_S_.Module.Infrastructure.ContainerConfiguration
{
    [InstallerPriority(1)]
    public class ContainerInstallerWindowsService : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<I_S_ShortProductName_S_Manager>().ImplementedBy<_S_ShortProductName_S_Manager>());
            container.Register(Component.For<ServiceBase>().ImplementedBy<_S_ShortProductName_S_WindowsService>());
            container.Register(Component.For<I_S_ShortProductName_S_WindowsService2>().ImplementedBy<_S_ShortProductName_S_WindowsService2>());
            var defaultServiceHostFactory = new DefaultServiceHostFactory(container.Kernel);
            container.Register(Component.For<DefaultServiceHostFactory>().Instance(defaultServiceHostFactory));
        }
    }
}