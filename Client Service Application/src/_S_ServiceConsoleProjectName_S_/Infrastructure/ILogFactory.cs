using System;
using Common.Logging;

namespace _S_ServiceConsoleProjectName_S_.Infrastructure
{
    public interface ILogFactory
    {
        ILog GetLogger(Type type);
    }
}