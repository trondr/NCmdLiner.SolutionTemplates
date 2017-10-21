using System;
using System.Threading;
using NUnit.Framework;
using _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions;

namespace _S_TestsProjectName_S_.Infrastructure.ContainerExtensions
{
    [TestFixture()]
    public class LogFactoryTests
    {
        [Test()]
        public void GetLoggerTest()
        {
            var target = new LogFactory();
            var logger = target.GetLogger(typeof(Type0));
            Assert.IsNotNull(logger);
        }

        [Test()]
        public void GetLoggerTestMultiThreaded()
        {
            var target = new LogFactory();
            var threads = new Thread[10];

            var failed = false;
            var failedMessage = string.Empty;
            var sync = new object();
            var threadStart = new ThreadStart(() =>
            {
                try
                {
                    var logger = target.GetLogger(typeof(Type0));
                    logger = target.GetLogger(typeof(Type1));
                    logger = target.GetLogger(typeof(Type2));
                    logger = target.GetLogger(typeof(Type3));
                    logger = target.GetLogger(typeof(Type4));
                    logger = target.GetLogger(typeof(Type5));
                    logger = target.GetLogger(typeof(Type6));
                    logger = target.GetLogger(typeof(Type7));
                    logger = target.GetLogger(typeof(Type8));
                    logger = target.GetLogger(typeof(Type9));
                }
                catch (Exception ex)
                {
                    lock (sync)
                    {
                        failed = true;
                        failedMessage = ex.Message;
                    }
                }
            });

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(threadStart);
            }

            foreach (var thread in threads)
            {
                thread.Start();
                Console.WriteLine($"Starting thread {thread.ManagedThreadId}");
            }

            foreach (var thread in threads)
            {
                thread.Join();
                Console.WriteLine($"Joining thread {thread.ManagedThreadId}");
            }

            Assert.IsFalse(failed, failedMessage);
        }
    }

    public class Type0 { }
    public class Type1 { }
    public class Type2 { }
    public class Type3 { }
    public class Type4 { }
    public class Type5 { }
    public class Type6 { }
    public class Type7 { }
    public class Type8 { }
    public class Type9 { }

}