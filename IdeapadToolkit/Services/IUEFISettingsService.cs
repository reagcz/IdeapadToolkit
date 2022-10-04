using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.Services
{
    public interface IUEFISettingsService
    {
        public int GetFlipToBootStatus();
        public int SetFlipToBootStatus(bool newStatus);
    }
}
