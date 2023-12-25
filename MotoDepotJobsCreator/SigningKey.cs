using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotoDepotJobsCreator
{
    internal class SigningKey : PublicKey
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



    }
}
