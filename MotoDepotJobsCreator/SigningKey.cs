using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MotoDepotJobsCreator
{
    internal class SigningKey
    {
        private const string PublicKeyFilename = "PublicKey.xml";
        private const string PrivateKeyFilename = "PrivateKey.xml";
        public static string KeysDirname = "keys";
       
        private const string Key = "33580704225959009476022150906537520183714542776639493478938153504813914707333";
        private const string Iv = "Bns9UYbayCPCUbzHhS5x2A==";

        public string Name { get; }
        public string PublicKey { get; }
        public string PrivateKey { get; }

        public string Error { get; set; }

        public SigningKey(string path)
        {
            if (path == null || string.IsNullOrWhiteSpace(path)) 
                throw new ArgumentNullException("Key path cannot be null or empty");

            if (!Directory.Exists(path))
                throw new ArgumentException("Path of signing key not exists.");

            Error = "";
            PublicKey = Path.Combine(path, PublicKeyFilename); ;
            PrivateKey = Path.Combine(path, PrivateKeyFilename); 
            Name = Path.GetFileName(path);
        }

        public bool Validate()
        {
            Error = "";
            if (!File.Exists(PublicKey))
            {

                Error = $"Public key not found. [AppExecDir]/{KeysDirname}/{Name}/{PublicKeyFilename}";
                return false;
            }

            if (!File.Exists(PrivateKey))
            {
                Error = $"Private key not found. [AppExecDir]/{KeysDirname}/{Name}/{PrivateKeyFilename}";
                return false;
            }

            return true;
        }

        public bool TestKey()
        {
            if (!Validate())
                return false;

            var xml = File.ReadAllText(PrivateKey);
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
                Error = "Invalid public/private key.";
                return false;
            }

            return true;
        }
        public bool hasError() {
            return !string.IsNullOrEmpty(Error);
        }

    }
}
