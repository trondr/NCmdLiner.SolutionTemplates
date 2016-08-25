using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using Common.Logging;
using NCmdLiner;
using _S_ServiceProjectName_S_.Infrastructure;

namespace _S_ServiceProjectName_S_
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            int returnValue;
            try
            {                
                returnValue = WireUpAndRun(args);
            }
            catch (Exception ex)
            {
                var message = string.Format("Fatal error when wiring up the application.{0}{1}", Environment.NewLine, ex);
                WriteErrorToEventLog(message);
                returnValue = 3;
            }
            return returnValue;
        }

        private static int WireUpAndRun(string[] args)
        {
            var returnValue = 0;
            var logger = GetMainLogger();
            using (var bootStrapper = new BootStrapper())
            {
                var applicationInfo = bootStrapper.Container.Resolve<IApplicationInfo>();
                try
                {
                    applicationInfo.Authors = @"_S_Authors_S_";
                    logger.InfoFormat("Start: {0}.{1}. Command line: {2}", applicationInfo.Name, applicationInfo.Version, Environment.CommandLine);
                    if (logger.IsInfoEnabled) logger.InfoFormat("Starting {0} - {1}. Command Line: {2}.", applicationInfo.Name, applicationInfo.Version, Environment.CommandLine);
                    var service = bootStrapper.Container.Resolve<ServiceBase>();
                    ServiceBase.Run(new[] { service });
                    returnValue = 0;
                    return returnValue;
                }
                catch (Exception ex)
                {
                    logger.ErrorFormat("Error when exeuting command. {0}", ex.ToString());
                    returnValue = 2;
                }
                finally
                {
                    logger.InfoFormat("Stop: {0}.{1}. Return value: {2}", applicationInfo.Name, applicationInfo.Version, returnValue);
#if DEBUG
                    // ReSharper disable once RedundantNameQualifier
                    System.Console.WriteLine("Terminating in 5 seconds...");
                    Thread.Sleep(5000);
#endif
                }
            }
            return returnValue;
        }


        private static ILog GetMainLogger()
        {
            try
            {
                var logger = LogManager.GetLogger<Program>();
                return logger;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get logger. ", ex);
            }
        }

        private static void WriteErrorToEventLog(string message)
        {
            // ReSharper disable once RedundantNameQualifier
            System.Console.WriteLine(message);
            const string logName = "Application";
            using (var eventLog = new EventLog(logName))
            {
                eventLog.Source = logName;
                eventLog.WriteEntry(message, EventLogEntryType.Information, 101, 1);
            }
        }

    }
}
