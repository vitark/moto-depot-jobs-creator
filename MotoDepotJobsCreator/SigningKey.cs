using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotoDepotJobsCreator
{
    public class SigningKey : PublicKey
    {
        protected const string privateKeyFile = "ServerPrivateKey.xml";
        private string privateKey { get; }
        public SigningKey(string path) : base(path)
        {
            privateKey = Path.Combine(path, privateKeyFile); 
        }

        public bool TestKey()
        {
            if (!Validate())
                return false;

            var xml = File.ReadAllText(privateKey);
            const string msg = "0123456789";

            var encodedResult = Encoder.Run(
                xml,
                Encoding.UTF8.GetBytes(msg),
                BigInteger.Parse(Key).ToByteArray(),
                Convert.FromBase64String(Iv)
            );

            var msgDecoded = Decoder.Run(
                xml,
                encodedResult.Msg,
                encodedResult.Key,
                encodedResult.Signature,
                Convert.FromBase64String(Iv)
            );

            if (msg != Encoding.UTF8.GetString(msgDecoded))
            {
                Error = "Invalid public key.";
                return false;
            }

            return true;
        }
        override public bool Validate()
        {
            if (!base.Validate())
                return false;

            if (!File.Exists(privateKey))
            {
                Error = $"Private key not found. [AppExecDir]/{KeysDirname}/{Name}/{privateKeyFile}";
                return false;
            }

            return true;
        }

        public static void CreateServerKey(string path)
        {
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider(2048);

            var ServerPublicKey = Path.Combine(path, publicKeyFile);
            using (var file = new StreamWriter(ServerPublicKey))
            {
                file.WriteLine(rsaCryptoServiceProvider.ToXmlString(false));
            }

            var ServerPrivateKey = Path.Combine(path, privateKeyFile);
            using (var file = new StreamWriter(ServerPrivateKey))
            {
                file.WriteLine(rsaCryptoServiceProvider.ToXmlString(true));
            }
        }

        public bool CreateDepotJobFile(string data, string depotJobFilename)
        {
            var encodedResult = Encoder.Run(
                File.ReadAllText(privateKey),
                Encoding.ASCII.GetBytes(data),
                BigInteger.Parse(Key).ToByteArray(),
                Convert.FromBase64String(Iv)
            );
            var xml = new List<char>();
            xml.AddRange("<DEPOT>\n");
            xml.AddRange("<DATA>" + Convert.ToBase64String(encodedResult.Key) + "</DATA>\n");
            xml.AddRange("<DATA>" + Iv + "</DATA>\n");
            xml.AddRange("<DATA>" + Convert.ToBase64String(encodedResult.Msg) + "</DATA>\n");
            xml.AddRange("<DATA>" + Convert.ToBase64String(encodedResult.Signature) + "</DATA>\n");
            xml.AddRange("</DEPOT>\n");
            var buffer = xml.Select(c => (byte)c).ToArray();

            var zip = new ZipOutputStream(File.Create(depotJobFilename));
            zip.SetLevel(0);
            var entry = new ZipEntry("config.dpt")
            {
                DateTime = DateTime.Now,
                Size = buffer.Length
            };
            zip.PutNextEntry(entry);
            zip.Write(buffer, 0, buffer.Length);
            zip.Close();

            return true;
        }


    }
}
