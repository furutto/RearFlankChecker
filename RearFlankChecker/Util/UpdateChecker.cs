using System;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RearFlankChecker.Util
{
    class UpdateChecker
    {
        public static string DoCheck()
        {
            string retMessage = "";
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName asmName = assembly.GetName();
            Version asmVersion = asmName.Version;
            String url = "https://api.github.com/repos/furutto/" + asmName.Name + "/releases/latest";
            String latestVersion = "";

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
                req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                var res = req.GetResponse();
                var resStream = res.GetResponseStream();

                var serializer = new DataContractJsonSerializer(typeof(GithubRESTData));
                GithubRESTData data = (GithubRESTData)serializer.ReadObject(resStream);
                latestVersion = data.tag_name;
                res.Close();


                if (latestVersion.StartsWith("v"))
                {
                    latestVersion = latestVersion.Substring(1);
                }

                if (asmVersion.ToString().StartsWith(latestVersion))
                {

                    retMessage = "最新バージョンです";
                }
                else
                {
                    retMessage = "新しいバージョン( " + latestVersion + " )があります";
                }

            }
            catch (Exception ex)
            {
                retMessage = ex.Message;
            }

            return retMessage;
        }

        public static string GetReleaseFileUrl()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName asmName = assembly.GetName();
            return "https://github.com/furutto/" + asmName.Name + "/releases";
        }

        [DataContract]
        internal class GithubRESTData
        {
            [DataMember]
            public string tag_name { get; set; }
        }
    }
}
