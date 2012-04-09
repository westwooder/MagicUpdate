using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using System.IO;

namespace MagicUpdate
{
    class Core
    {
        static WebClient client = new WebClient();

        public static string GetVersion(string url)
        {
            return client.DownloadString(new Uri(url));
        }

        public static void GetFile(string url, string fileName)
        {
            client.DownloadFile(new Uri(url), fileName);
        }

        public static string GetHash(String f)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            System.Security.Cryptography.MD5 hashAlgo = new System.Security.Cryptography.MD5CryptoServiceProvider();

            using (FileStream file = new FileStream(f, FileMode.Open, FileAccess.Read))
            {
                byte[] retVal = hashAlgo.ComputeHash(file);
                file.Close();
                return BitConverter.ToString(retVal).Replace("-", "");
            }
        }

        public static bool ValFile(string md5Code, string fileName)
        {
            return GetHash(fileName) == md5Code;
        }
    }
}
