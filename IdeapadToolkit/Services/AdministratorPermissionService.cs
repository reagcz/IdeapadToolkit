using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.Services
{
    public class AdministratorPermissionService : IAdministratorPermissionService
    {
        public bool IsAdministrator
        {
            get
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public void RelaunchAsAdmin()
        {
            var proc = new Process
            {
                StartInfo =
                    {FileName = Environment.ProcessPath, UseShellExecute = true, Verb = "runas", Arguments="ignoreRunning"}
            };
            proc.Start();
            Environment.Exit(0);
        }
    }
}
