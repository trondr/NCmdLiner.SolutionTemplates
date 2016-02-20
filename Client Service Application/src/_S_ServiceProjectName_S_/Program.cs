﻿using System;
using System.ServiceProcess;
using System.Threading;
using Common.Logging;
using NCmdLiner;
using NCmdLiner.Exceptions;
using _S_ServiceProjectName_S_.Infrastructure;
using _S_ServiceProjectName_S_.Module;

namespace _S_ServiceProjectName_S_
{
    class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            int returnValue = 0;
            var applicationInfo = BootStrapper.Container.Resolve<IApplicationInfo>();
            var logger = LogManager.GetLogger<Program>();
            applicationInfo.Authors = "_S_Authors_S_";
            try
            {
                if (logger.IsInfoEnabled) logger.InfoFormat("Starting {0} - {1}. Command Line: {2}.", applicationInfo.Name, applicationInfo.Version, Environment.CommandLine);                
                ServiceBase.Run(new ServiceBase[] { BootStrapper.Container.Resolve<ServiceBase>() });
                returnValue = 0;
            }
            catch (MissingCommandException ex)
            {
                if (logger.IsErrorEnabled) logger.Error(ex);
                returnValue = 1;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) logger.Error(ex);
                returnValue = 2;
            }
            finally
            {
                if (logger.IsInfoEnabled) logger.InfoFormat("Stopping {0} - {1}. Return value: {2}", applicationInfo.Name, applicationInfo.Version, returnValue);
#if DEBUG
                System.Console.WriteLine("Terminating in 5 seconds...");
                Thread.Sleep(5000);
#endif
            }
            return returnValue;
        }
    }
}
