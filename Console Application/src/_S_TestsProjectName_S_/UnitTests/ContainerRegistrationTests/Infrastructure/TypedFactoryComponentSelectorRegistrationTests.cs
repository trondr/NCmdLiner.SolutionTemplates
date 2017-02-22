using Castle.Facilities.TypedFactory;
using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class TypedFactoryComponentSelectorRegistrationTests
    {
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
    }
}