using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_LibraryProjectName_S_.Module.Services;

namespace _S_ConsoleProjectName_S_.Module.Infrastructure.ContainerConfiguration
{
    [InstallerPriority(InstallerPriorityAttribute.DefaultPriority)]
    public class ContainerInstallerWcfService: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Manual registrations
            container.Register(
                Component.For<I_S_ShortProductName_S_ManagerFacade>()
                    .ImplementedBy<_S_ShortProductName_S_ManagerFacade>());
        }
    }
}