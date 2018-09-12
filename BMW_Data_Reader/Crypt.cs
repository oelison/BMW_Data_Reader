using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SciPhyLib
{
    public static class Crypt
    {
        private const string initData = "s92mnfasWjDL39Jw";
        private const int keysize = 256;

        public static string Encrypt(String text, String password)
        {
            String encryptedText;
            // prepare text
            byte[] textArray = Encoding.UTF8.GetBytes(text);
            // prepare password
            byte[] passwordArray = new PasswordDeriveBytes(password, null).GetBytes(keysize / 8);
            // choose encryption method
            RijndaelManaged symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };
            // prepare transformer with init data
            byte[] initDataBytes = Encoding.UTF8.GetBytes(initData);
            ICryptoTransform encryptTransformer = symmetricKey.CreateEncryptor(passwordArray, initDataBytes);
            // encrypt
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptTransformer, CryptoStreamMode.Write);
            cryptoStream.Write(textArray, 0, textArray.Length);
            cryptoStream.FlushFinalBlock();
            byte[] encryptedTextArray = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            encryptedText = Convert.ToBase64String(encryptedTextArray);
            return encryptedText;
        }

        public static string Decrypt(String encryptedText, String passPhrase)
        {
            String text;
            // prepare encrypted text
            byte[] encryptedTextArray = Convert.FromBase64String(encryptedText);
            // prepare password
            byte[] passwordArray = new PasswordDeriveBytes(passPhrase, null).GetBytes(keysize / 8);
            // choose decryption method
            RijndaelManaged symmetricKey = new RijndaelManaged
            {
                Mode = CipherMode.CBC
            };
            // prepare transformer with init data
            byte[] initDataBytes = Encoding.UTF8.GetBytes(initData);
            ICryptoTransform decryptTransformer = symmetricKey.CreateDecryptor(passwordArray, initDataBytes);
            // decrypt
            MemoryStream memoryStream = new MemoryStream(encryptedTextArray);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptTransformer, CryptoStreamMode.Read);
            byte[] textArray = new byte[encryptedTextArray.Length];
            int decryptedByteCount = cryptoStream.Read(textArray, 0, textArray.Length);
            memoryStream.Close();
            cryptoStream.Close();
            text =  Encoding.UTF8.GetString(textArray, 0, decryptedByteCount);
            return text;
        }
    }
}
