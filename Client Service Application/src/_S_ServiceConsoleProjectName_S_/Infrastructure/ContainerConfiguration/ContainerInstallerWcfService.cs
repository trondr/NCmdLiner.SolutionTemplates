using System;
using Castle.Facilities.TypedFactory;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using _S_LibraryProjectName_S_.Module.Common.Services;
using _S_ServiceConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_ServiceContractsProjectName_S_;
using _S_ServiceLibraryProjectName_S_.Module;

namespace _S_ServiceConsoleProjectName_S_.Infrastructure.ContainerConfiguration
{
    [InstallerPriority(1)]
    public class ContainerInstallerWcfService : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>(facility => facility.CloseTimeout = TimeSpan.Zero);
            container.Register(Component.For<I_S_ShortProductName_S_Manager>().ImplementedBy<_S_ShortProductName_S_Manager>());
            var defaultServiceHostFactory = new DefaultServiceHostFactory(container.Kernel);
            container.Register(Component.For<DefaultServiceHostFactory>().Instance(defaultServiceHostFactory));

            container.Register(Component.For<IKeepAliveServiceFactory>().AsFactory());
            container.Register(
                Component.For<IKeepAliveService>()
                    .ImplementedBy<KeepAliveService>()
                    .Named("KeepAliveService")
                    .LifeStyle.Transient);
        }
    }
}