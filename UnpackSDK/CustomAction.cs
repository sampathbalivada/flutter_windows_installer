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
            void UnZipProgress(object sender, ExtractProgressEventArgs e)
            {
                if (e.EventType == ZipProgressEventType.Extracting_AfterExtractEntry)
                {
                    if(e.EntriesExtracted % 50 == 0)
                    {
                        string actionMessage = "Extracting files... (" + e.EntriesExtracted.ToString() + " of " + e.EntriesTotal.ToString() + " files extracted)";
                        //session.Log(actionMessage);
                        Record record = new Record("callAddProgressInfo", actionMessage, "");
                        session.Message(InstallMessage.ActionStart, record);
                    }
                }
            }

            try
            {
                string userProfilePath = System.Environment.GetEnvironmentVariable("USERPROFILE");
                string basePath = userProfilePath + @"\flutter";
                string path = basePath + @"\flutter_sdk.zip";
                // Check if the requried directory exists and create the directory if it doesn't
                if (!Directory.Exists(path))
                {
                    // Extract flutter_sdk.zip to C:\
                    using (ZipFile zipFile = new ZipFile(path))
                    {
                        zipFile.ExtractProgress += UnZipProgress;
                        zipFile.ExtractAll(userProfilePath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch (Exception e)
            {
                session.Log(e.ToString());
                return ActionResult.Failure;
            }

            session.Log("Extracted");

            return ActionResult.Success;        
        }

    }
}
