using System;
using System.Diagnostics;
using System.Threading;
using Common.Logging;
using NCmdLiner;
using _S_ConsoleProjectName_S_.Infrastructure;
using _S_LibraryProjectName_S_.Infrastructure;

namespace _S_ConsoleProjectName_S_
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
                WriteErrorToEventLog($"Fatal error when wiring up the application.{Environment.NewLine}{ex}");
                returnValue = 3;
            }
            return returnValue;
        }

        private static int WireUpAndRun(string[] args)
        {
            var exitCode = 0;
            var logger = GetMainLogger();
            using (var bootStrapper = new BootStrapper())
            {
                exitCode = Run(args, bootStrapper, logger);
            }
            return exitCode;
        }

        private static int Run(string[] args, BootStrapper bootStrapper, ILog logger)
        {
            var exitCode = 0;
            var applicationInfo = bootStrapper.Container.Resolve<IApplicationInfo>();
            try
            {
                applicationInfo.Authors = @"_S_Authors_S_";
                // ReSharper disable once CoVariantArrayConversion
                object[] commandTargets = bootStrapper.Container.ResolveAll<CommandDefinition>();
                logger.Info($"Start: {applicationInfo.Name}.{applicationInfo.Version}. Command line: {Environment.CommandLine}");
                CmdLinery.RunEx(commandTargets, args, applicationInfo, bootStrapper.Container.Resolve<IMessenger>())
                    .OnFailure(exception =>
                    {
                        exitCode = 1;
                        logger.Error(exception.Message);
                    });                
            }
            catch (Exception ex)
            {
                logger.ErrorFormat($"Error when exeuting command.{Environment.NewLine}{ex}");
                exitCode = 2;
            }
            finally
            {
                logger.Info($"Stop: {applicationInfo.Name}.{applicationInfo.Version}. Return value: {exitCode}");
#if DEBUG
                // ReSharper disable once RedundantNameQualifier
                System.Console.WriteLine("Terminating in 5 seconds...");
                Thread.Sleep(5000);
#endif
            }
            return exitCode;
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
