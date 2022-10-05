# Ideapad Toolkit

**Ideapad Toolkit is a utility that allows you adjust the power setting from Lenovo Vantage, without having to use the slow official app**

![image](https://user-images.githubusercontent.com/62750643/193948650-76596fe5-fab3-44aa-b656-fe15a2d93f46.png)


**Power profiles can be quickly adjusted from the tray icon**

![image](https://user-images.githubusercontent.com/62750643/193938407-4f96a444-4c29-44be-90e0-f6c4e182dbce.png)

**After running, the app windows can be accessed by double clicking the tray icon**
## Supported laptops
- Lenovo Flex 5 14ALC05 (Windows 11)

If your model is similar enough, chances are it will work.

To test, try changing the settings and verify the changes in Lenovo Vantage

## Prerequisites
- [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-6.0.9-windows-x64-installer)

- [Lenovo Intelligent Thermal Solution Driver](https://www.google.com/search?q=lenovo+<YOUR+MODEL>+intelligent+thermal+solution+driver+download)

- PowerBattery.dll
  - This dll needs to be placed in the same directory as the executable
  
### How to get PowerBattery.dll
 1. Install Lenovo Vantage from the Microsoft Store
 2. Copy it from C:\ProgramData\Lenovo\Vantage\Addins\IdeaNotebookAddin\ to the Ideapad Toolkit directory
 3. Lenovo Vantage can now be uninstalled
 
 ## Third party licenses
 [Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon/blob/develop/LICENSE)
 
 [ModernWpf](https://github.com/Kinnara/ModernWpf/blob/master/LICENSE)
 
 [SimpleInjector](https://github.com/simpleinjector/SimpleInjector/blob/master/LICENSE)
 
 [.NET Community Toolkit](https://github.com/CommunityToolkit/dotnet/blob/main/License.md)
 
