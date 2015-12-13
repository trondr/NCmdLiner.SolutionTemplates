using System;
using Common.Logging;

namespace _S_ServiceProjectName_S_.Infrastructure
{
    public interface ILogFactory
    {
        ILog GetLogger(Type type);
    }
}