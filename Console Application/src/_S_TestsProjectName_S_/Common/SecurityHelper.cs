﻿using System.Security.Principal;

namespace _S_TestsProjectName_S_.Common
{
    public class SecurityHelper
    {
        public static string GetCurrentWindowsIdentityName()
        {
            var windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
                return windowsIdentity.Name;
            return "<unknown>";
        }

        public static bool IsInRole(string role)
        {
            var windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity == null) return false;
            var principal = new WindowsPrincipal(windowsIdentity);
            return principal.IsInRole(role);
        }
    }
}
