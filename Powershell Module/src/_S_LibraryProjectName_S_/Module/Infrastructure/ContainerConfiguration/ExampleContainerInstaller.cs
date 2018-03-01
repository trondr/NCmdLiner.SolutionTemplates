using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using _S_LibraryProjectName_S_.Infrastructure.ContainerExtensions;
using _S_LibraryProjectName_S_.Module.ViewModels;
using _S_LibraryProjectName_S_.Module.Views;

namespace _S_LibraryProjectName_S_.Module.Infrastructure.ContainerConfiguration
{
    [InstallerPriority(InstallerPriorityAttribute.DefaultPriority)]
    public class ExampleContainerInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Manual registrations
            container.Register(Component.For<MainWindow>().Activator<StrictComponentActivator>());
            container.Register(Component.For<MainView>().Activator<StrictComponentActivator>());
            container.Register(Component.For<MainViewModel>().Activator<StrictComponentActivator>());

            //Factory registrations example:

            //container.Register(Component.For<ITeamProviderFactory>().AsFactory());
            //container.Register(
            //    Component.For<ITeamProvider>()
            //        .ImplementedBy<CsvTeamProvider>()
            //        .Named("CsvTeamProvider")
            //        .LifeStyle.Transient);
            //container.Register(
            //    Component.For<ITeamProvider>()
            //        .ImplementedBy<SqlTeamProvider>()
            //        .Named("SqlTeamProvider")
            //        .LifeStyle.Transient);
        }
    }
}
