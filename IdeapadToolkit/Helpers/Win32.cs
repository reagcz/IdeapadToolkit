using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static IdeapadToolkit.Services.UEFISettingsService;
using static Vanara.PInvoke.Kernel32;

namespace IdeapadToolkitService.Helpers
{
    public class Win32
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


        //public static Win32Error GetFirmwareEnvironmentVariableExW(string lpName, string lpGuid, IntPtr pBuffer, int nSize)
        //{
        //    VARIABLE_ATTRIBUTE at = new();
        //    return Vanara.PInvoke.Kernel32.GetFirmwareEnvironmentVariableEx(lpName, lpGuid, pBuffer, (uint)nSize, out at);
        //}

        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetFirmwareEnvironmentVariableExW(
           [MarshalAs(UnmanagedType.LPWStr)] string lpName,
           [MarshalAs(UnmanagedType.LPWStr)] string lpGuid,
           ref LenovoFlipToBootSwInterface pBuffer,
           int nSize,
           int attribute);

        //public static bool SetFirmwareEnvironmentVariableExW(string lpName,
        //  string lpGuid,
        //   IntPtr pBuffer,
        //   int nSize,
        //   int attribute)
        //{
        //    VARIABLE_ATTRIBUTE at = new();
        //    return Vanara.PInvoke.Kernel32.SetFirmwareEnvironmentVariableEx(lpName, lpGuid, pBuffer, (uint)nSize, at);
        //}

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
