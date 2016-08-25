using System;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using _S_ServiceProjectName_S_.Infrastructure.ContainerExtensions;

namespace _S_ServiceProjectName_S_.Infrastructure.ContainerConfiguration
{
    [InstallerPriority(1)]
    public class ContainerInstallerWcfService : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>(facility => facility.CloseTimeout = TimeSpan.Zero);                        
        }
    }
}