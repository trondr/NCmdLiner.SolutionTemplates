using Castle.DynamicProxy;

namespace _S_ConsoleProjectName_S_.Infrastructure.ContainerExtensions
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