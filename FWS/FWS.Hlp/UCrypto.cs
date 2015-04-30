using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace FWS.Hlp
{
    public class Criptografia
    {

        //public static string Tag = "viver_android";
        public static string Tag = ConfigurationManager.AppSettings["TAG"];
        private static byte[] _passwordKey;
        
        // Replace me with a 16-byte key, share between Java and C#
        private static readonly byte[] RawSecretKey = {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                              0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

        public static string Decrypt(string valor)
        {
            _passwordKey = encodeDigest(Tag);
            var encryptedData = Convert.FromBase64String(valor);
            return Encoding.Default.GetString(new RijndaelManaged().CreateDecryptor(_passwordKey, RawSecretKey)
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length));

            /*Teste Viver */
            //return Encoding.ASCII.GetString(new RijndaelManaged().CreateDecryptor(_passwordKey, RawSecretKey)
            //    .TransformFinalBlock(encryptedData, 0, encryptedData.Length));

        }
        public static string Encrypt(string valor)
        {
            _passwordKey = encodeDigest(Tag);
            var toEncryptArray = Encoding.Default.GetBytes(valor);
            var retorno =
                new RijndaelManaged().CreateEncryptor(_passwordKey, RawSecretKey)
                    .TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(retorno, 0, retorno.Length);
        }

        private static byte[] encodeDigest(string text)
        {
            var x = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(text);
            return x.ComputeHash(data);
        }
    }
}
