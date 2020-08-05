# Flutter Windows Installer

Flutter is Google’s UI toolkit for building beautiful, natively compiled applications for [mobile](https://flutter.dev/docs), [web](https://flutter.dev/web), and [desktop](https://flutter.dev/desktop) from a single codebase.

For more info on Flutter head over to [https://flutter.dev](https://flutter.dev)

<br/>



## System Requirements

To install and run Flutter, your development environment must meet these minimum requirements:

- **Operating Systems**: Windows 7 SP1 or later (64-bit)

- **Disk Space**: 2 GB on C:\ Drive (does not include disk space for IDE/tools).

- **Tools**

  Flutter depends on these tools being available in your environment.

  - [Windows PowerShell 5.0](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-windows-powershell) or newer (this is pre-installed with Windows 10)

  - [Git for Windows](https://git-scm.com/download/win) 2.x, with the **Use Git from the Windows Command Prompt** option.

    If Git for Windows is already installed, make sure you can run `git` commands from the command prompt or PowerShell.
    
    

<br />



## Installation Steps

1. Download and run the flutter installer from the below link

   [FlutterSDK_Installer-x64-Win.msi](https://github.com/sampathbalivada/flutter_windows_installer/releases/tag/v0.1.0-beta)

   >  *Note: The Flutter Installer will download a package >600MB in size and unpacks to the **C:\flutter** directory.* 

2. Run the following command from a new Command Prompt or PowerShell window to finish setting up your 

   ```$ flutter doctor```

   *For more information about ``flutter doctor`` visit [https://flutter.dev/docs/get-started/install/windows#run-flutter-doctor](https://flutter.dev/docs/get-started/install/windows#run-flutter-doctor)*
   
## Install Using WinGet

The installer will be added to WinGet repository after a Stable version is released. Currently the installer is in Beta.

<br />



## Troubleshooting

1. The flutter installer is taking too much time on the **Extracting Files** page.

   *The flutter SDK archive is highly compressed and can take up to 20 minutes to extract on slower machines.*

2. The installer terminated prematurely or the installation aborted.

   *It is possible that your C:\ Drive is out of space. Make sure that you have at least 2GB of free space on your C:\ Volume.*

3. My problem isn't listed here or the above solutions do not work.

   *If your problem isn't listed here, please create an issue and make sure to include details about your OS*

<br/>

<br/>



*Flutter and the related logo are trademarks of Google LLC*
