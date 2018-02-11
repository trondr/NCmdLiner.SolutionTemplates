using System.Security.AccessControl;
using System.Security.Principal;

namespace _S_ServiceProjectName_S_.Infrastructure.Security
{
    public class ServiceAccessRule : AccessRule
    {
        public ServiceAccessRule(IdentityReference identity, ServiceAccessRights accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
            : base(identity, (int)accessMask, isInherited, inheritanceFlags, propagationFlags, type)
        {
        }

        public ServiceAccessRights ServiceAccessRights => (ServiceAccessRights)AccessMask;
    }
}