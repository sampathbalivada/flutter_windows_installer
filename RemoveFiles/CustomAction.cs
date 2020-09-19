using Microsoft.Deployment.WindowsInstaller;

namespace RemoveFiles
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult RemoveFiles(Session session)
        {
            string basePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + @"\flutter";
            // Create a new process and delete the directory C:\flutter using the 
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C RMDIR /Q/S " + basePath;
            process.StartInfo = startInfo;
            process.Start();

            return ActionResult.Success;
        }
    }
}

