using System;
using Microsoft.Deployment.WindowsInstaller;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.ComponentModel;

namespace DownloadAndUnpack
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult DownloadSDK(Session session)
        {
            int currentProgress = 0;
            void HandleDownloadProgress (object sender, DownloadProgressChangedEventArgs e)
            {
                if(e.ProgressPercentage != currentProgress)
                {
                    currentProgress = e.ProgressPercentage;
                    string actionMessage = "Downloading SDK... (" + currentProgress.ToString() + "% completed)";
                    //session.Log(actionMessage);
                    Record record = new Record("callAddProgressInfo", actionMessage, "");
                    session.Message(InstallMessage.ActionStart, record);
                }
            }

            void HandleDownloadComplete(object sender, AsyncCompletedEventArgs e)
            {
                if(e.Error != null)
                {
                    session.Log(e.Error.Message);
                }
                Thread.Sleep(10000);
                lock (e.UserState)
                {
                    //releases blocked thread
                    Monitor.Pulse(e.UserState);
                }
            }


            string basePath = @"C:\flutter";
            WebClient client = new WebClient();
            try
            {
                // Check if the requried directory exists and create the directory if it doesn't
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                client.DownloadProgressChanged += HandleDownloadProgress;
                client.DownloadFileCompleted += HandleDownloadComplete;

                //Uri downloadUri = new Uri("http://127.0.0.1:8000/flutter_sdk.zip");
                Uri downloadUri = new Uri(InstallerLink.GetLink());

                var syncObject = new Object();
                lock (syncObject)
                {
                    client.DownloadFileAsync(downloadUri, basePath + @"\flutter_sdk.zip", syncObject);
                    //This will block the thread until download completes
                    Monitor.Wait(syncObject);
                }

            }
            catch (Exception e)
            {
                session.Log(e.ToString());
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }
    }



    public class InstallerLink
    {
        public class CurrentRelease
        {
            public string beta { get; set; }
            public string dev { get; set; }
            public string stable { get; set; }
        }

        public class ReleaseDetails
        {
            public string hash { get; set; }
            public string channel { get; set; }
            public string version { get; set; }
            public string release_date { get; set; }
            public string archive { get; set; }
            public string sha256 { get; set; }
        }

        public class Data
        {
            public string base_url { get; set; }
            public CurrentRelease current_release { get; set; }
            public ReleaseDetails[] releases { get; set; }
        }
        public static string GetLink()
        {
            WebClient client = new WebClient();
            string apiData = Encoding.ASCII.GetString(client.DownloadData("https://storage.googleapis.com/flutter_infra/releases/releases_windows.json"));
            Data deserializedData = JsonConvert.DeserializeObject<Data>(apiData);

            // Find the archive location of current stable release
            string archiveLocation = "";
            for (int i = 0; i < deserializedData.releases.Length; ++i)
            {
                if (deserializedData.releases[i].hash == deserializedData.current_release.stable)
                {
                    archiveLocation = deserializedData.releases[i].archive;
                }
            }
            return deserializedData.base_url + "/" + archiveLocation;
        }
    }
}