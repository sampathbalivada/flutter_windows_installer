using System;
using Microsoft.Deployment.WindowsInstaller;
using Ionic.Zip;
using System.IO;

namespace UnpackSDK
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult UnpackSDK(Session session)
        {
            try
            {
                string path = @"C:\flutter\flutter_sdk.zip";
                // Check if the requried directory exists and create the directory if it doesn't
                if (!Directory.Exists(path))
                {
                    // Extract flutter_sdk.zip to C:\
                    using (ZipFile zipFile = new ZipFile(path))
                    {
                        foreach (ZipEntry e in zipFile)
                        {
                            e.Extract(@"C:\");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                session.Log(e.ToString());
                return ActionResult.Failure;
            }

            //session.Log("Extracted");

            return ActionResult.Success;        
        }
    }
}
