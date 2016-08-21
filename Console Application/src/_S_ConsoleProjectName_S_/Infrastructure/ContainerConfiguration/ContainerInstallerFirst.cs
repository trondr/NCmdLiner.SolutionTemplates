using System;
using System.IO;
using Castle.Core.Internal;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using NCmdLiner;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.ViewModels;
using _S_LibraryProjectName_S_.Module.Views;
using SingletonAttribute = _S_LibraryProjectName_S_.Infrastructure.SingletonAttribute;

namespace _S_ConsoleProjectName_S_.Infrastructure.ContainerConfiguration
{
    [InstallerPriority(0)]
    public class ContainerInstallerFirst : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<ITypedFactoryComponentSelector>().ImplementedBy<CustomTypeFactoryComponentSelector>());
            container.Register(Component.For<IMessenger>().ImplementedBy<NotepadMessenger>());
            //
            //   Configure logging
            //
            ILoggingConfiguration loggingConfiguration = new LoggingConfiguration();
            log4net.GlobalContext.Properties["LogFile"] = Path.Combine(loggingConfiguration.LogDirectoryPath, loggingConfiguration.LogFileName);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
            var applicationRootNameSpace = typeof (Program).Namespace;
            container.Kernel.Register(Component.For<ILog>().Instance(LogManager.GetLogger(applicationRootNameSpace))); //Default logger
            container.Kernel.Resolver.AddSubResolver(new LoggerSubDependencyResolver()); //Enable injection of class specific loggers            
        }
    }
}
