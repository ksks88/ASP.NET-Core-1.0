using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestDecrypt
{
    class Program
    {
        public const string PREFIX_RIJNDAEL = "r1:";

        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("HASH: {0}  --- PASSWORD: {1}", "r1:MyzlJNYTgziw97wmz0ZOYw==", Decrypt("r1:MyzlJNYTgziw97wmz0ZOYw==")));
            Console.ReadLine();
        }

        public static string Decrypt(string sEncryptedText)
        {
            try
            {
                if (String.IsNullOrEmpty(sEncryptedText))
                {
                    return String.Empty;
                }

                string sPrefix = PREFIX_RIJNDAEL;
                if (sEncryptedText.StartsWith(sPrefix) == false)
                {
                    return null;
                }
                sEncryptedText = sEncryptedText.Substring(sPrefix.Length);

                byte[] oBytes = Convert.FromBase64String(sEncryptedText);
                MemoryStream oStream = new MemoryStream(oBytes, false);
                oStream.Seek(0, SeekOrigin.Begin);
                Rijndael oEncrypt = System.Security.Cryptography.Rijndael.Create();

                byte[] oKey = new byte[16] { 27, 119, 45, 117, 110, 72, 171, 54, 27, 119, 115, 27, 110, 72, 171, 54 };
                byte[] oVector = new byte[16] { 127, 19, 145, 127, 110, 172, 71, 154, 127, 19, 145, 127, 10, 172, 111, 154 };
                ICryptoTransform oTransform = oEncrypt.CreateDecryptor(oKey, oVector);

                CryptoStream oEncryptedStream = new CryptoStream(oStream, oTransform, CryptoStreamMode.Read);
                BinaryReader oReader = new BinaryReader(oEncryptedStream);
                return oReader.ReadString();
            }
            catch (Exception oException)
            {
                Debug.Assert(false, oException.Message);
                return null; ;
            }
        }
    }
}
