using System;
using System.IO;
using System.Threading;
using Common.Logging;

namespace _S_LibraryProjectName_S_.Module.Common.Services
{
    public class KeepAliveService : IKeepAliveService
    {
        private readonly string _keepAliveFile;
        private readonly ILog _logger;
        private bool _isActivated;

        public KeepAliveService(string keepAliveFile, ILog logger)
        {
            _keepAliveFile = keepAliveFile;
            _logger = logger;
        }

        public void Activate()
        {
            using (File.CreateText(_keepAliveFile)) { }
            _isActivated = true;
            do
            {
                while (!Console.KeyAvailable && KeepAlive())
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Write("+");
                if (!KeepAlive())
                    break;
                Thread.Sleep(1000);
            } while ((Console.ReadKey(true).Key != ConsoleKey.Escape) && KeepAlive());
            Console.WriteLine();
        }

        public bool KeepAlive()
        {
            if (!_isActivated)
            {
                throw new InvalidOperationException("KeepAliveService has not been activated.");
            }
            bool keepAlive = File.Exists(_keepAliveFile);
            if (!keepAlive)
            {
                _logger.InfoFormat("Keep alive file '{0}' does not exist. Preparing to terminate...", _keepAliveFile);
            }
            return File.Exists(_keepAliveFile);
        }

        public void Release()
        {
            if (File.Exists(_keepAliveFile))
            {
                _logger.Info("Releasing keep alive process by deleting the keep alive file: " + _keepAliveFile);
                File.Delete(_keepAliveFile);
            }
        }

        ~KeepAliveService()
        {
            Dispose(false);            
        }
        
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                Release();
            }
            // free native resources if there are any.
        }
    }
}