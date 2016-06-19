using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure;

namespace _S_TestsProjectName_S_.Common
{
    public static class BootStrapperTestsHelper
    {
        public static void CheckThatNumberOfResolvedServicesAre<T>(int numberOfServices)
        {
            CheckThatNumberOfResolvedServicesAre<T>(numberOfServices, string.Empty);
        }

        public static void CheckThatNumberOfResolvedServicesAre<T>(int numberOfServices, string message)
        {
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.ResolveAll<T>();
                Assert.AreEqual(numberOfServices, target.Length, string.Format("Number of resolved '{0}' was not expected. {1}", typeof(T).Name, message));
            }
        }

        public static void CheckThatResolvedServiceIsOfInstanceType<T, TV>()
        {
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.Resolve<T>();
                Assert.AreEqual(typeof(TV), target.GetType(), string.Format("'{0}' was not of type '{1}'", typeof(T).Name, typeof(TV).Name));
            }
        }

        public static void CheckThatResolvedServiceHasSingletonLifeCycle<T>()
        {
            using (var bootStrapper = new BootStrapper())
            {
                var target1 = bootStrapper.Container.ResolveAll<T>();
                var target2 = bootStrapper.Container.ResolveAll<T>();
                Assert.AreEqual(target1.Length, target2.Length, string.Format("Sequent calls to ResolveAll on service '{0}' results in unequal number of services beeing resolved.", typeof(T).Name));
                for (int i = 0; i < target1.Length; i++)
                {
                    Assert.AreEqual(target1[i].GetHashCode(), target2[i].GetHashCode(), string.Format("Instance '{1}' of service '{0}' is not a singleton object.", typeof(T).Name, target1[i].GetType().Name));
                }
            }
        }

        public static void CheckThatResolvedServiceHasTransientLifeCycle<T>()
        {
            using (var bootStrapper = new BootStrapper())
            {
                var target1 = bootStrapper.Container.ResolveAll<T>();
                var target2 = bootStrapper.Container.ResolveAll<T>();
                Assert.AreEqual(target1.Length, target2.Length, string.Format("Sequent calls to ResolveAll on service '{0}' results in unequal number of services beeing resolved.", typeof(T).Name));
                for (int i = 0; i < target1.Length; i++)
                {
                    Assert.AreNotEqual(target1[i].GetHashCode(), target2[i].GetHashCode(), string.Format("Instance '{1}' of service '{0}' is not a transient object.", typeof(T).Name, target1[i].GetType().Name));
                }
            }
        }

        public static void CheckThatResolvedServiceIsSameAsInstance<T>(T instance)
        {
            using (var bootStrapper = new BootStrapper())
            {
                var target = bootStrapper.Container.Resolve<T>();                              
                Assert.AreEqual(instance.GetHashCode(), target.GetHashCode(), string.Format("Resolved instance of service '{0}' is not the same as input instance.", typeof(T).Name));
            }
        }
    }
}
