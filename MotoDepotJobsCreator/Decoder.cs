using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace MotoDepotJobsCreator
{
    internal abstract class Decoder
    {
        public static byte[] Run(
            string xml,
            byte[] msgBytes,
            byte[] keyBytes,
            byte[] signature,
            byte[] iv
        )
        {
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            rsaCryptoServiceProvider.FromXmlString(xml);

            if (!rsaCryptoServiceProvider.VerifyHash(
                    new SHA256Managed().ComputeHash(msgBytes),
                    CryptoConfig.MapNameToOID("SHA256"),
                    signature
                ))
                throw new Exception("signature mismatch");

            var keyDecoded = DecodeKey(rsaCryptoServiceProvider, keyBytes);

            var aesManaged = new AesManaged();
            aesManaged.KeySize = 256;
            aesManaged.BlockSize = 128;
            aesManaged.Mode = CipherMode.CBC;
            aesManaged.Key = keyDecoded;
            aesManaged.IV = iv;

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, aesManaged.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(msgBytes, 0, msgBytes.Length);
            cryptoStream.Flush();
            ((IDisposable)cryptoStream).Dispose();
            return memoryStream.ToArray();
        }

        private static byte[] DecodeKey(RSACryptoServiceProvider rsaCryptoServiceProvider, byte[] rawBytes)
        {
            var rsaParameters = rsaCryptoServiceProvider.ExportParameters(false);
            var data = BigInteger.ModPow(
                new BigInteger(rawBytes),
                ConvertBytesToBigInteger(rsaParameters.Exponent),
                ConvertBytesToBigInteger(rsaParameters.Modulus)
            ).ToByteArray();
            var result = new byte[data.Length - 5];
            Array.Copy(data, result, result.Length);
            Array.Reverse(result);
            return result;
        }

        internal static BigInteger ConvertBytesToBigInteger(byte[] rawBytes)
        {
            var data = (byte[])rawBytes.Clone();
            Array.Reverse(data);
            var result = new byte[data.Length + 1];
            Array.Copy(data, result, data.Length);
            return new BigInteger(result);
        }
    }
}