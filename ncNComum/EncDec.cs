using System;
using System.IO;
using System.Security.Cryptography;

namespace ncNComum
{
    public class EncDec
    {
        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            var ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            var cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            return ms.ToArray();
        }

        public static string Encrypt(string clearText, string Password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            var pdb = new PasswordDeriveBytes(Password, new byte[] {
                0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D,
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        public static byte[] Encrypt(byte[] clearData, string Password)
        {
            var pdb = new PasswordDeriveBytes(Password, new byte[] {
                0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D,
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        public static void Encrypt(string fileIn, string fileOut, string Password)
        {
            var fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            var fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
            var pdb = new PasswordDeriveBytes(Password, new byte[] {
                0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D,
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            var cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;
            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
            cs.Close();
            fsIn.Close();
        }

        public static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            var ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            var cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            return ms.ToArray();
        }

        public static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            var pdb = new PasswordDeriveBytes(Password, new byte[] {
                0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D,
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        public static byte[] Decrypt(byte[] cipherData, string Password)
        {
            var pdb = new PasswordDeriveBytes(Password, new byte[] {
                0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D,
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));
        }

        public static void Decrypt(string fileIn, string fileOut, string Password)
        {
            var fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            var fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);
            var pdb = new PasswordDeriveBytes(Password, new byte[] {
                0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D,
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);
            var cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);
            int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int bytesRead;
            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);
            cs.Close();
            fsIn.Close();
        }
    }
}
