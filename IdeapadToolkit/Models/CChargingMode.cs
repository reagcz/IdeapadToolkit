using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.Models
{
    [NativeCppClass]
    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct CChargingMode
    {
        private long value;
    }
}
