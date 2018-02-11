using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;

namespace _S_ServiceProjectName_S_.Infrastructure.Security
{
    public class ServiceSecurity : NativeObjectSecurity
    {
        public ServiceSecurity(SafeHandle serviceHandle)
            : base(false, ResourceType.Service, serviceHandle, AccessControlSections.Access)
        {

        }

        public void AddAccessRule(ServiceAccessRule rule)
        {
            base.AddAccessRule(rule);
        }

        public void RemoveAccessRule(ServiceAccessRule serviceAccessRule)
        {
            base.RemoveAccessRule(serviceAccessRule);
        }

        public void SaveChanges(SafeHandle processHandle)
        {
            Persist(processHandle, AccessControlSections.Access);
        }

        public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited,
            InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
        {
            return new ServiceAccessRule(identityReference, (ServiceAccessRights)accessMask, isInherited, inheritanceFlags, propagationFlags, type);
        }

        public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited,
            InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
        {
            throw new NotImplementedException();
        }

        public override Type AccessRightType => typeof(ServiceAccessRights);
        public override Type AccessRuleType => typeof(ServiceAccessRule);
        public override Type AuditRuleType => throw new NotImplementedException();
    }
}
