using NUnit.Framework;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_TestsProjectName_S_.Common;

namespace _S_TestsProjectName_S_.UnitTests.ContainerRegistrationTests.Infrastructure
{
    [TestFixture(Category = "UnitTests")]
    public class TypeMapperRegistrationTests
    {
        [Test, RequiresSTA]
        public void TypeMapperRegistrationTest()
        {
            BootStrapperTestsHelper.CheckThatNumberOfResolvedServicesAre<ITypeMapper>(1);
            BootStrapperTestsHelper.CheckThatResolvedServiceIsOfInstanceType<ITypeMapper, TypeMapper>();
            BootStrapperTestsHelper.CheckThatResolvedServiceHasSingletonLifeCycle<ITypeMapper>();
        }
    }
}