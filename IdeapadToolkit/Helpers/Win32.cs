using System;
using System.Runtime.InteropServices;
using System.Text;
using static IdeapadToolkit.Services.UEFISettingsService;

namespace IdeapadToolkitService.Helpers
{
    internal class Win32
    {
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
          int dwDesiredAccess,
          bool bInheritHandle,
          int dwProcessId);

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetApplicationUserModelId(
          IntPtr hProcess,
          ref uint appModelIdLength,
          [MarshalAs(UnmanagedType.LPWStr)] StringBuilder sbAppUserModelId);


        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetFirmwareEnvironmentVariableExW([MarshalAs(UnmanagedType.LPWStr)] string lpName, [MarshalAs(UnmanagedType.LPWStr)] string lpGuid, ref LenovoFlipToBootSwInterface pBuffer, int nSize, IntPtr pAttribute);


        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetFirmwareEnvironmentVariableExW(
           [MarshalAs(UnmanagedType.LPWStr)] string lpName,
           [MarshalAs(UnmanagedType.LPWStr)] string lpGuid,
           ref LenovoFlipToBootSwInterface pBuffer,
           int nSize,
           int attribute);


        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetCurrentProcess();

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool LookupPrivilegeValue(
          string lpSystemName,
          string lpName,
          ref long lpLuid);

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AdjustTokenPrivileges(
          IntPtr tokenHandle,
          [MarshalAs(UnmanagedType.Bool)] bool disableAllPrivileges,
          ref TokenPrivelege newState,
          int zero,
          IntPtr null1,
          IntPtr null2);

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(
          IntPtr processHandle,
          uint desiredAccess,
          ref IntPtr tokenHandle);

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetFirmwareType(ref FirmwareType firmwareType);
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
