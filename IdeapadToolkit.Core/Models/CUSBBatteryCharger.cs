using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IdeapadToolkit.Core.Models
{
    [NativeCppClass]
    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct CUSBBatteryCharger
    {
        private long value;
    }
}
