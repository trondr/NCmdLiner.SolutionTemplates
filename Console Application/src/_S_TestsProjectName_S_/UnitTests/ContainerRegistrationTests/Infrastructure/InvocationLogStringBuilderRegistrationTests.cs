using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category=TestCategory.UnitTests)]
    public class InvocationLogStringBuilderRegistrationTests
    {
        [Test, RequiresSTA]
        public void InvocationLogStringBuilderRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<IInvocationLogStringBuilder>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<IInvocationLogStringBuilder, InvocationLogStringBuilder>();
        }
    }
}