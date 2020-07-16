using System;
using Microsoft.Deployment.WindowsInstaller;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DownloadAndUnpack
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult DownloadSDK(Session session)
        {
            string basePath = @"C:\flutter";
            WebClient client = new WebClient();
            try
            {
                // Check if the requried directory exists and create the directory if it doesn't
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                // Use this in release mode
                client.DownloadFile(InstallerLink.GetLink(), basePath + @"\flutter_sdk.zip");

                // Use this when debugging using a local server
                //client.DownloadFile("http://127.0.0.1:8000/flutter_sdk.zip", basePath + @"\flutter_sdk.zip");

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