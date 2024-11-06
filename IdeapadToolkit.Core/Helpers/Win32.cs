using System.Runtime.InteropServices;
using static IdeapadToolkit.Core.Services.UEFISettingsService;

namespace IdeapadToolkit.Core.Helpers
{
    internal partial class Win32
    {
        [LibraryImport("kernel32.dll")]
        public static partial nint OpenProcess(
          int dwDesiredAccess,
          [MarshalAs(UnmanagedType.Bool)]
          bool bInheritHandle,
          int dwProcessId);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        public static partial int GetFirmwareEnvironmentVariableExW([MarshalAs(UnmanagedType.LPWStr)] string lpName, [MarshalAs(UnmanagedType.LPWStr)] string lpGuid, ref LenovoFlipToBootSwInterface pBuffer, int nSize, nint pAttribute);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        public static partial int SetFirmwareEnvironmentVariableExW(
           [MarshalAs(UnmanagedType.LPWStr)] string lpName,
           [MarshalAs(UnmanagedType.LPWStr)] string lpGuid,
           ref LenovoFlipToBootSwInterface pBuffer,
           int nSize,
           int attribute);

        [LibraryImport("kernel32.dll")]
        public static partial nint GetCurrentProcess();

        [LibraryImport("advapi32.dll", StringMarshalling = StringMarshalling.Utf16)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool LookupPrivilegeValueW(
          string lpSystemName,
          string lpName,
          ref long lpLuid);

        [LibraryImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool AdjustTokenPrivileges(
          nint tokenHandle,
          [MarshalAs(UnmanagedType.Bool)] bool disableAllPrivileges,
          ref TokenPrivelege newState,
          int zero,
          nint null1,
          nint null2);

        [LibraryImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool OpenProcessToken(
          nint processHandle,
          uint desiredAccess,
          ref nint tokenHandle);

        [LibraryImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool GetFirmwareType(ref FirmwareType firmwareType);
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TokenPrivelege
    {
        public int Count;
        public long Luid;
        public int Attr;
    }
    public enum FirmwareType
    {
        FirmwareTypeUnknown,
        FirmwareTypeBios,
        FirmwareTypeUefi,
        FirmwareTypeMax,
    }
}
