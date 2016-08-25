using System;
using Common.Logging;

namespace _S_ServiceConsoleProjectName_S_.Infrastructure.ContainerExtensions
{
    public interface ILogFactory
    {
        ILog GetLogger(Type type);
    }
}