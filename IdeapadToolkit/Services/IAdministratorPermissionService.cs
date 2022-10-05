using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.Services
{
    public interface IAdministratorPermissionService
    {
        public bool IsAdministrator { get; }
        public void RelaunchAsAdmin();
    }
}
