using System;
using System.IO;
using Microsoft.Deployment.WindowsInstaller;

namespace OpenREADME
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult OpenREADME(Session session)
        {
            string basePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + @"\flutter";
            string path = basePath + @"\InstallREADME.txt";

            string[] lines = {
                "For more information on Flutter Doctor",
                "visit https://flutter.dev/docs/get-started/install/windows#run-flutter-doctor",
                "",
                "For details about installing Android Studio and/or Visual Studio Code visit",
                "Android Studio - https://developer.android.com/studio",
                "Visual Studio Code - https://code.visualstudio.com/",
                "",
                "Note: Flutter relies on a full installation of Android Studio to supply its Android platform dependencies.",
                "However, you can write your Flutter apps in a number of editors.",
                "",
                "If you've already downloaded and installed your editor,",
                "follow the link below to setup Flutter plugins",
                "https://flutter.dev/docs/get-started/editor",
                "",
                "To know more about the Flutter SDK",
                "visit https://flutter.dev",
            };

            try
            {
                string flutterBinPath = basePath + @"\bin";
                // Write contents to the README file.
                File.WriteAllLines(path, lines);

                // Open README File after writing
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = @"/C notepad.exe /a "+ basePath + @"\InstallREADME.txt";
                process.StartInfo = startInfo;
                process.Start();

                _ = System.Diagnostics.Process.Start("cmd.exe", "/K SET PATH=\""+ flutterBinPath + "\";%PATH% & cd " + flutterBinPath + @" & flutter doctor");
            }
            catch (Exception e)
            {
                session.Log(e.ToString());
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }
    }
}
