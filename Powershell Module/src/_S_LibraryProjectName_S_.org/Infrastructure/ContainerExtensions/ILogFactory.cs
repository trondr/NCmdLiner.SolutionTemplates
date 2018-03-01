using System;
using Common.Logging;

namespace _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions
{
    public interface ILogFactory
    {
        ILog GetLogger(Type type);
    }
}