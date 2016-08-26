using Castle.Windsor;
using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class ContainerRegistrationTests
    {
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
    }
}