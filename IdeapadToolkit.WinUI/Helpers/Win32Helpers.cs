using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IdeapadToolkit.WinUI3.Helpers;
public static partial class Win32
{
    [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16)]
    public static partial int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    public const uint MB_OK = 0x00000000;
    public const uint MB_ICONASTERISK = 0x00000040;
}
