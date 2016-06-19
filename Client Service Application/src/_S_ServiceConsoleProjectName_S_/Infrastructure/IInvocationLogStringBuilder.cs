using Castle.DynamicProxy;

namespace _S_ServiceConsoleProjectName_S_.Infrastructure
{
    public interface IInvocationLogStringBuilder
    {
        string BuildLogString(IInvocation invocation, InvocationPhase invocationPhase);
    }

    public enum InvocationPhase
    {
        Start,
        End,
        Error
    }
}