//Source: http://csharptest.net/browse/src/Library/Services/ServiceAccessRights.cs
#region Copyright 2011-2014 by Roger Knapp, Licensed under the Apache License, Version 2.0
/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;

namespace _S_ServiceProjectName_S_.Infrastructure.Security
{
    /// <summary>
    /// Access control rights specific to a Win32 Service
    /// </summary>
    [Flags]
    public enum ServiceAccessRights
    {
        /// <summary>
        /// Required to call the QueryServiceConfig and 
        /// QueryServiceConfig2 functions to query the service configuration.
        /// </summary>
        ServiceQueryConfig = 0x00001,

        /// <summary>
        /// Required to call the ChangeServiceConfig or ChangeServiceConfig2 function 
        /// to change the service configuration. Because this grants the caller 
        /// the right to change the executable file that the system runs, 
        /// it should be granted only to administrators.
        /// </summary>
        ServiceChangeConfig = 0x00002,

        /// <summary>
        /// Required to call the QueryServiceStatusEx function to ask the service 
        /// control manager about the status of the service.
        /// </summary>
        ServiceQueryStatus = 0x00004,

        /// <summary>
        /// Required to call the EnumDependentServices function to enumerate all 
        /// the services dependent on the service.
        /// </summary>
        ServiceEnumerateDependents = 0x00008,

        /// <summary>
        /// Required to call the StartService function to start the service.
        /// </summary>
        ServiceStart = 0x00010,

        /// <summary>
        ///     Required to call the ControlService function to stop the service.
        /// </summary>
        ServiceStop = 0x00020,

        /// <summary>
        /// Required to call the ControlService function to pause or continue 
        /// the service.
        /// </summary>
        ServicePauseContinue = 0x00040,

        /// <summary>
        /// Required to call the EnumDependentServices function to enumerate all
        /// the services dependent on the service.
        /// </summary>
        ServiceInterrogate = 0x00080,

        /// <summary>
        /// Required to call the ControlService function to specify a user-defined
        /// control code.
        /// </summary>
        ServiceUserDefinedControl = 0x00100,

        // From ACCESS_MASK
        /// <summary> READ_CONTROL, DELETE, WRITE_DAC, WRITE_OWNER </summary>
        StandardRightsRequired = 0x000f0000,
        /// <summary> READ_CONTROL </summary>
        StandardRightsRead = 0x00020000,
        /// <summary> READ_CONTROL </summary>
        StandardRightsWrite = 0x00020000,
        /// <summary> READ_CONTROL </summary>
        StandardRightsExecute = 0x00020000,

        /// <summary>
        /// Includes STANDARD_RIGHTS_REQUIRED in addition to all access rights in this table.
        /// </summary>
        ServiceAllAccess = (StandardRightsRequired |
                              ServiceQueryConfig |
                              ServiceChangeConfig |
                              ServiceQueryStatus |
                              ServiceEnumerateDependents |
                              ServiceStart |
                              ServiceStop |
                              ServicePauseContinue |
                              ServiceInterrogate |
                              ServiceUserDefinedControl),

        /// <summary>
        /// Includes STANDARD_RIGHTS_READ, SERVICE_QUERY_CONFIG, SERVICE_QUERY_STATUS, SERVICE_INTERROGATE and SERVICE_ENUMERATE_DEPENDENTS.
        /// </summary>
        GenericRead = StandardRightsRead |
                       ServiceQueryConfig |
                       ServiceQueryStatus |
                       ServiceInterrogate |
                       ServiceEnumerateDependents,

        /// <summary>
        /// Includes STANDARD_RIGHTS_WRITE and SERVICE_CHANGE_CONFIG.
        /// </summary>
        GenericWrite = StandardRightsWrite |
                        ServiceChangeConfig,

        /// <summary>
        /// Includes STANDARD_RIGHTS_EXECUTE, SERVICE_START, SERVICE_STOP, SERVICE_PAUSE_CONTINUE, and SERVICE_USER_DEFINED_CONTROL
        /// </summary>
        GenericExecute = StandardRightsExecute |
                          ServiceStart |
                          ServiceStop |
                          ServicePauseContinue |
                          ServiceUserDefinedControl,

        /// <summary>
        /// Required to call the QueryServiceObjectSecurity or 
        /// SetServiceObjectSecurity function to access the SACL. The proper
        /// way to obtain this access is to enable the SE_SECURITY_NAME 
        /// privilege in the caller's current access token, open the handle 
        /// for ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
        /// </summary>
        AccessSystemSecurity = 0x01000000, //ACCESS_MASK.ACCESS_SYSTEM_SECURITY,

        /// <summary>
        /// Required to call the DeleteService function to delete the service.
        /// </summary>
        Delete = 0x00010000, //ACCESS_MASK.DELETE,

        /// <summary>
        /// Required to call the QueryServiceObjectSecurity function to query
        /// the security descriptor of the service object.
        /// </summary>
        ReadControl = 0x00020000, //ACCESS_MASK.READ_CONTROL,

        /// <summary>
        /// Required to call the SetServiceObjectSecurity function to modify
        /// the Dacl member of the service object's security descriptor.
        /// </summary>
        WriteDac = 0x00040000, //ACCESS_MASK.WRITE_DAC,

        /// <summary>
        /// Required to call the SetServiceObjectSecurity function to modify 
        /// the Owner and Group members of the service object's security 
        /// descriptor.
        /// </summary>
        WriteOwner = 0x00080000, //ACCESS_MASK.WRITE_OWNER,
    }
}