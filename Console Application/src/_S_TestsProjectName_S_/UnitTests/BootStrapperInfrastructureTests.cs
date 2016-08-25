using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Common.Logging;
using Common.Logging.Simple;
using NCmdLiner;
using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Module.ViewModels;
using _S_LibraryProjectName_S_.Module.Views;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests
{
    [TestFixture(Category = "UnitTests")]
    public class BootStrapperInfrastructureTests
    {
        private ConsoleOutLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ConsoleOutLogger(this.GetType().Name, LogLevel.All, true, false, false, "yyyy-MM-dd hh:mm:ss");
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test, RequiresSTA]
        public void ContainerRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IWindsorContainer>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IWindsorContainer, WindsorContainer>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IWindsorContainer>();
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.Resolve<IWindsorContainer>();
                Assert.AreEqual(bootStrapper.Container.GetHashCode(), target.GetHashCode(), string.Format("Instance of service '{0}' is not the same.", typeof(IWindsorContainer)));
            }
        }
        
        [Test, RequiresSTA]
        public void TypedFactoryComponentSelectorRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<ITypedFactoryComponentSelector>(3);
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<ITypedFactoryComponentSelector>();
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.ResolveAll<ITypedFactoryComponentSelector>();                
                Assert.AreEqual(typeof(CustomTypeFactoryComponentSelector), target[2].GetType(), "The third ITypedFactoryComponentSelector instance was not of type CustomTypeFactoryComponentSelector");
            }
        }

        [Test, RequiresSTA]
        public void NCmdLinerCommandDefinitionRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<CommandDefinition>(1, "The number should equal the number of service implementations. The programmer should manually adjust the expected number in this unit test for each added or removed service implementation.");
        }

        [Test, RequiresSTA]
        public void NCmdLinerIApplicationInfoRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IApplicationInfo>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IApplicationInfo, ApplicationInfo>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IApplicationInfo>();
        }
        
        [Test, RequiresSTA]
        public void NCmdLinerIMessengerRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IMessenger>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IMessenger, NotepadMessenger>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<IMessenger>();
        }

        [Test, RequiresSTA]
        public void InvocationLogStringBuilderRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IInvocationLogStringBuilder>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IInvocationLogStringBuilder, InvocationLogStringBuilder>();
        }

        [Test, RequiresSTA]
        public void InfoLogAspectRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<InfoLogAspect>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<InfoLogAspect, InfoLogAspect>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<InfoLogAspect>();
        }

        [Test, RequiresSTA]
        public void DebugLogAspectRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<DebugLogAspect>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<DebugLogAspect, DebugLogAspect>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<DebugLogAspect>();
        }

        [Test, RequiresSTA]
        public void LogFactoryRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<ILogFactory>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<ILogFactory, LogFactory>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<ILogFactory>();
        }
        
        [Test, RequiresSTA]
        public void TraceLogAspectRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<TraceLogAspect>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<TraceLogAspect, TraceLogAspect>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<TraceLogAspect>();
        }
        
        [Test, RequiresSTA]
        public void MainViewModelRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<MainViewModel>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<MainViewModel,MainViewModel>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<MainViewModel>();
        }

        [Test, RequiresSTA]
        public void MainViewRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<MainView>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<MainView, MainView>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<MainView>();
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.ResolveAll<MainView>();                
                Assert.IsNotNull(target[0].ViewModel, "ViewModel was null");
            }
        }

        [Test, RequiresSTA]
        public void MainWindowRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<MainWindow>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<MainWindow, MainWindow>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<MainWindow>();
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.ResolveAll<MainWindow>();
                Assert.IsNotNull(target[0].View, "View was null");
                Assert.IsNotNull(target[0].View.ViewModel, "View.ViewModel was null");
            }
        }

        [Test, RequiresSTA]
        public void TypeMapperRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<ITypeMapper>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<ITypeMapper,TypeMapper>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<ITypeMapper>();
        }
    }
}