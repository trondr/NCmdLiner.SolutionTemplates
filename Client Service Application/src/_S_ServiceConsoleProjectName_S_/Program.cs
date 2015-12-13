using System;
using System.Threading;
using Common.Logging;
using NCmdLiner;
using NCmdLiner.Exceptions;
using _S_LibraryProjectName_S_.Infrastructure;
using _S_ServiceProjectName_S_.Infrastructure;

namespace _S_ServiceConsoleProjectName_S_
{
    class Program
    {
                [STAThread]
        static int Main(string[] args)
        {
            var returnValue = 0;
            try
            {
                var logger = LogManager.GetLogger<Program>();
                var applicationInfo = BootStrapper.Container.Resolve<IApplicationInfo>();
                try
                {
                    applicationInfo.Authors = @"_S_Authors_S_";
                    // ReSharper disable once CoVariantArrayConversion
                    object[] commandTargets = BootStrapper.Container.ResolveAll<CommandDefinition>();
                    logger.InfoFormat("Start: {0}.{1}. Command line: {2}", applicationInfo.Name, applicationInfo.Version, Environment.CommandLine);                    
                    returnValue = CmdLinery.Run(commandTargets, args, applicationInfo, new NotepadMessenger());
                    return returnValue;
                }
                catch (MissingCommandException ex)
                {
                    logger.ErrorFormat("Missing command. {0}", ex.Message);
                    returnValue = 1;
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
                    Console.WriteLine("Terminating in 5 seconds...");
                    Thread.Sleep(5000);
#endif
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error when wiring up the application.{0}{1}", Environment.NewLine, ex);
                returnValue = 3;
            }
            return returnValue;
        }
    }    
}
