﻿using System;
using System.Collections.Concurrent;
using System.Threading;
using Common.Logging;

namespace _S_ServiceConsoleProjectName_S_.Infrastructure.ContainerExtensions
{
    public class LogFactory : ILogFactory
    {
        private ConcurrentDictionary<Type, ILog> LoggersDictionary
        {
            get
            {
                if (_loggersDictionary == null)
                {
                    lock (_sync)
                    {
                        if (_loggersDictionary == null)
                        {
                            _loggersDictionary = new ConcurrentDictionary<Type, ILog>();
                        }
                    }
                }
                return _loggersDictionary;
            }
        }
        private ConcurrentDictionary<Type, ILog> _loggersDictionary;
        private readonly object _sync = new object();

        public ILog GetLogger(Type type)
        {
            Console.WriteLine($"Checking logger for type {type.Name} on thread {Thread.CurrentThread.ManagedThreadId}");
            if (!LoggersDictionary.ContainsKey(type))
            {
                var logger = LogManager.GetLogger(type);
                LoggersDictionary.AddOrUpdate(type, logger, (type1, log) => logger);
            }
            Console.WriteLine($"Returning logger for type {type.Name} on thread {Thread.CurrentThread.ManagedThreadId}");
            return LoggersDictionary[type];
        }
    }
}
