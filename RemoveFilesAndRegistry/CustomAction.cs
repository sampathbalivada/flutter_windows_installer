using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;

namespace RemoveFilesAndRegistry
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult RemoveFilesAndRegistry(Session session)
        {
            // Deleting Registy value for Version number
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{714D2060-D72C-4CDD-992C-0F6AA6819772}", true);

            // Delete the value
            key.DeleteValue("DisplayVersion");

            // Create a new process and delete the directory C:\flutter\flutter_sdk.zip using the 
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C DEL /Q/S C:\flutter\flutter_sdk.zip";
            process.StartInfo = startInfo;
            process.Start();

            return ActionResult.Success;
        }
    }
}
