# Ideapad Toolkit

**Ideapad Toolkit is a utility that allows you to adjust your Ideapad's power settings without installing Lenovo Vantage**

![image](https://user-images.githubusercontent.com/62750643/193948650-76596fe5-fab3-44aa-b656-fe15a2d93f46.png)

**Power profiles can be quickly adjusted from the tray icon**

![image](https://user-images.githubusercontent.com/62750643/193938407-4f96a444-4c29-44be-90e0-f6c4e182dbce.png)

**After running, the app windows can be accessed by double clicking the tray icon**
## Tested laptops
- Ideapad Flex 5 14ALC05 (Windows 11)
- Ideapad 5 Pro 16ACH6 - 82L5 (Windows 10 22H2)

If you find your model is compatible and not on the list, please sumbit an issue

To test, try changing the settings and verify if the settings change accordingly in Lenovo Vantage or the UEFI

## Prerequisites
- [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-6.0.9-windows-x64-installer)

- [Lenovo Intelligent Thermal Solution Driver](https://www.google.com/search?q=lenovo+<YOUR+MODEL>+intelligent+thermal+solution+driver+download)

- Visual C++ 2015 Runtime
  - This comes packed with most Windows software, so you most likely already have this.
  - If not, install from here: [X64](https://aka.ms/vs/17/release/vc_redist.x64.exe) [X86](https://aka.ms/vs/17/release/vc_redist.x86.exe)

- PowerBattery.dll
  - This dll needs to be placed in the same directory as the executable
  
### How to get PowerBattery.dll
- Method A
  1. Install Lenovo Vantage from the Microsoft Store
  2. Copy it from C:\ProgramData\Lenovo\Vantage\Addins\IdeaNotebookAddin\ to the Ideapad Toolkit directory
  3. Lenovo Vantage can now be uninstalled
- Method B (Without Microsoft Store)
  1.  Go to https://store.rg-adguard.net/
  2.  Enter the link to Lenovo Vantage (https://apps.microsoft.com/store/detail/lenovo-vantage/9WZDNCRFJ4MV)
  3.  Download the newest version in the **.msixbundle** format (The file should be called "something LevovoCompanion something **.msixbundle**)
  4.  Open the .msixbundle file using 7Zip or similar software
  5.  Inside 7Zip, navigate to LenovoVantagePackage\[Version\]x64.msix/DeployAssistant/ImController/Plugins\[Version\].cab/plugins.7z/Normal/IdeaNotebookPlugin/x64
  6.  PowerBattery.dll should be in there


 ## Third party licenses
 [Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon/blob/develop/LICENSE)
 
 [ModernWpf](https://github.com/Kinnara/ModernWpf/blob/master/LICENSE)
 
 [SimpleInjector](https://github.com/simpleinjector/SimpleInjector/blob/master/LICENSE)
 
 [.NET Community Toolkit](https://github.com/CommunityToolkit/dotnet/blob/main/License.md)
 
 [Serilog](https://github.com/serilog/serilog/blob/dev/LICENSE)

