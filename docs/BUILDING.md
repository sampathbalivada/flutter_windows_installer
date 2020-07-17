# Flutter Windows Installer

### 🔨 Tools

* [WiX Toolset](https://wixtoolset.org/)
* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/)

<br/>



### Steps to build the installer

1. Clone the repository into a local directory

   ```powershell
   git clone https://github.com/sampathbalivada/flutter_installer_wix.git
   ```

2. Open ``/FlutterInstaller.sln`` in a new Visual Studio window.

3. Select Release or Debug configuration in the Toolbar.

4. Press **F7** or click **Build > Build Solution** in the File Menu bar.

5. The built installer can be found at ``/FlutterInstaller/bin `` directory.

6. To generate log files for the installer run this from a command window. Make sure to cd into the installer binary directory.

   ```powershell
   msiexec /i FlutterSDK-x64.msi /l*v FlutterInstallerLogFile.txt
   ```

<br/>



### Custom Actions

The Custom Actions created in the installer are **C#** actions built using **.NET 3.5** for maximum compatibility.