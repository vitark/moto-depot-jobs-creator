using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace MotoDepotJobsCreator
{
    internal struct Result
    {
        internal byte[] Msg;
        internal byte[] Signature;
        internal byte[] Key;
    }

    internal abstract class Encoder
    {
        public static Result Run(
            string xml,
            byte[] msgBytes,
            byte[] keyBytes,
            byte[] iv
        )
        {
            if (keyBytes.Length != 32) throw new Exception("the key must be 32 bytes long");
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            rsaCryptoServiceProvider.FromXmlString(xml);

            var key = PrepareKey(rsaCryptoServiceProvider, keyBytes);

            var aesManaged = new AesManaged();
            aesManaged.KeySize = 256;
            aesManaged.BlockSize = 128;
            aesManaged.Mode = CipherMode.CBC;
            aesManaged.Key = keyBytes;
            aesManaged.IV = iv;

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aesManaged.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(msgBytes, 0, msgBytes.Length);
            cryptoStream.Flush();
            ((IDisposable)cryptoStream).Dispose();
            var data = memoryStream.ToArray();

            return new Result
            {
                Msg = data,
                Signature = rsaCryptoServiceProvider.SignHash(
                    new SHA256Managed().ComputeHash(data),
                    CryptoConfig.MapNameToOID("SHA256")
                ),
                Key = key
            };
        }


        private static byte[] PrepareKey(RSACryptoServiceProvider rsaCryptoServiceProvider, IEnumerable<byte> rawBytes)
        {
            var list = new List<byte>();
            list.AddRange(rawBytes);
            list.Reverse();
            list.AddRange(new byte[] { 1, 1, 1, 1, 1 });
            var rsaParameters = rsaCryptoServiceProvider.ExportParameters(true);
            var result = BigInteger.ModPow(
                new BigInteger(list.ToArray()),
                Decoder.ConvertBytesToBigInteger(rsaParameters.D),
                Decoder.ConvertBytesToBigInteger(rsaParameters.Modulus)
            ).ToByteArray();
            return result;
        }
    }
}