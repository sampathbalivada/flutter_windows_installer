# Flutter Windows Installer

### 🔨 Tools

* [WiX Toolset](https://wixtoolset.org/)
* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)

### NuGet Packages

* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)
* [DotNetZip.Reduced](https://www.nuget.org/packages/DotNetZip.Reduced/)

<br/>



### ⚠ Important Notes

*The installler is a web installer and it is not required to build a new installer for every release of the Flutter SDK.*

If we need to add features to the installer and if that requires a bump in the installer version number, make sure to update the Id attribute of Product with new GUID in the following locations

* ``/FlutterInstaller/Product.wxs``
* ``/RemoveFilesAndRegistry/CustomAction.cs``

<br/>



### ✔ Testing

##### Platforms Tested

- [x] Windows 7
- [x] Windows 8
- [x] Windows 10

##### Tests Performed

* Install Fluttter SDK
* Run ``$ flutter doctor`` from a new terminal
* Build and run ``hello_world`` app on an emulator or device ([Android Studio](https://developer.android.com/studio) or Android SDK is required to perform this test)
* Uninstall Flutter SDK

<br/>



### Additonal Documentation

You can find the build guide in the [BUILDING.md](BUILDING.md) file.

<br />



### Authors

The Flutter Windows Insatller is authored and tested by 

* [@sampathbalivada](https://github.com/sampathbalivada)

* [@csells](https://github.com/csells)

