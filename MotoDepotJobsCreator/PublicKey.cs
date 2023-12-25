using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MotoDepotJobsCreator
{
    internal class PublicKey
    {
        public static string KeysDirname = "keys";
        public static string MotorolaPublicKey = "MotorolaServerPublicKey.xml";

        public static string publicKeyFile = "ServerPublicKey.xml";
        protected const string Key = "33580704225959009476022150906537520183714542776639493478938153504813914707333";
        protected const string Iv = "Bns9UYbayCPCUbzHhS5x2A==";

        public string Name { get; }
        protected string publicKey { get; }
        public string Error { get; set; }

        public PublicKey(string path, string fileName = "")
        {
            if (path == null || string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Key path cannot be null or empty");

            if (!Directory.Exists(path))
                throw new ArgumentException("Path of signing key not exists.");

            Error = "";
            if (!string.IsNullOrEmpty(fileName))
                publicKeyFile = fileName;

            publicKey = Path.Combine(path, publicKeyFile);
            Name = Path.GetFileName(path);
        }

        virtual public bool Validate()
        {
            Error = "";
            if (!File.Exists(publicKey))
            {
                Error = $"Public key not found. [AppExecDir]/{KeysDirname}/{Name}/{publicKeyFile}";
                return false;
            }

            return true;
        }
        
        public bool hasError()
        {
            return !string.IsNullOrEmpty(Error);
        }

        public string decode(string depotJobFilename)
        {
            string output = "Fail to decode file.";
            var zip = new ZipInputStream(File.Open(depotJobFilename, FileMode.Open));
            while (zip.GetNextEntry() != null)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(zip);

                var list = xmlDoc.GetElementsByTagName("DATA");
                if (list.Count != 4)
                    return "Incorect format of depot job file.";
                    
                output = Encoding.UTF8.GetString(
                        Decoder.Run(
                            File.ReadAllText(publicKey),
                            Convert.FromBase64String(list[2].InnerText),
                            Convert.FromBase64String(list[0].InnerText),
                            Convert.FromBase64String(list[3].InnerText),
                            Convert.FromBase64String(list[1].InnerText)
                        )
                    );
                
            }

            zip.Close();

            return output;
        }

    }
}
