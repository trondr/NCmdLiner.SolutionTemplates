using System;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading;
using Common.Logging;
using NCmdLiner;
using Topshelf;
using _S_ServiceProjectName_S_.Infrastructure;
using _S_ServiceProjectName_S_.Infrastructure.Security;
using _S_ServiceProjectName_S_.Module;

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
                returnValue = WireUpAndRunNew(args);
            }
            catch (Exception ex)
            {
                WriteErrorToEventLog($"Fatal error when wiring up the application.{Environment.NewLine}{ex}");
                returnValue = 3;
            }
            return returnValue;
        }

        private static int WireUpAndRunNew(string[] args)
        {
            var returnValue = 0;
            var logger = GetMainLogger();
            using (var bootStrapper = new BootStrapper())
            {
                var applicationInfo = bootStrapper.Container.Resolve<IApplicationInfo>();
                try
                {
                    applicationInfo.Authors = @"_S_Authors_S_";
                    logger.Info($"Start: {applicationInfo.Name}.{applicationInfo.Version}. Command line: {Environment.CommandLine}");                    
                    var returnCode = HostFactory.Run(configurator =>
                        {
                            configurator.UseLog4Net();
                            configurator.Service<I_S_ShortProductName_S_WindowsService2>(settings =>
                                {
                                    settings.ConstructUsing(hostSettings => bootStrapper.Container.Resolve<I_S_ShortProductName_S_WindowsService2>());
                                    settings.WhenStarted(service => service.Start());
                                    settings.WhenStopped(service => service.Stop());
                                    
                                });
                            configurator.RunAsLocalSystem();
                            configurator.SetDescription("_S_ServiceDescription_S_");
                            configurator.SetDisplayName("_S_ProductName_S_ Service");
                            configurator.SetServiceName("_S_ShortProductName_S_Service");
                            configurator.AfterInstall(settings =>
                            {
                                logger.Info($"Configuring service permissions allowing built in users to stop and start {settings.Name} service.");
                                using (var serviceController = new ServiceController(settings.Name))
                                {
                                    var serviceSecurity = new ServiceSecurity(serviceController.ServiceHandle);
                                    var identity = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
                                    serviceSecurity.AddAccessRule(new ServiceAccessRule(identity, ServiceAccessRights.ServiceStop | ServiceAccessRights.ServiceStart, false, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
                                    serviceSecurity.SaveChanges(serviceController.ServiceHandle);
                                }
                            });
                        });
                    var exitCode = (int)Convert.ChangeType(returnCode, typeCode: returnCode.GetTypeCode());
                    Environment.ExitCode = exitCode;
                    returnValue = 0;                    
                    return returnValue;
                }
                catch (Exception ex)
                {
                    logger.Error($"Error when exeuting command. {ex}");
                    returnValue = 2;
                }
                finally
                {
                    logger.Info($"Stop: {applicationInfo.Name}.{applicationInfo.Version}. Return value: {returnValue}");
#if DEBUG
                    // ReSharper disable once RedundantNameQualifier
                    System.Console.WriteLine("Terminating in 5 seconds...");
                    Thread.Sleep(5000);
#endif
                }
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
