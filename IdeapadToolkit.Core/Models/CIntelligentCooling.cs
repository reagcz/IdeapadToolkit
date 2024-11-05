using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IdeapadToolkit.Core.Models
{
    [NativeCppClass]
    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct CIntelligentCooling
    {
        private long value;
    }
}
