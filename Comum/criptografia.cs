using System;
using System.IO;
using System.Security.Cryptography;

namespace Comum
{
    public class criptografia
    {
        private string sKy = "chavede0criptografia9nascomercio"; // 32 chars
        private string sIV = "vetorde9criptografia0nascomercio"; // 32 chars

        public string Criptografar(string texto)
        {
            var myRijndael = new RijndaelManaged();
            try
            {
                myRijndael.Padding = PaddingMode.Zeros;
                myRijndael.Mode = CipherMode.CBC;
                myRijndael.KeySize = 256;
                myRijndael.BlockSize = 256;

                byte[] key = System.Text.Encoding.ASCII.GetBytes(sKy);
                byte[] IV = System.Text.Encoding.ASCII.GetBytes(sIV);

                ICryptoTransform encryptor = myRijndael.CreateEncryptor(key, IV);

                var msEncrypt = new MemoryStream();
                var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

                byte[] toEncrypt = System.Text.Encoding.ASCII.GetBytes(texto);
                csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                csEncrypt.FlushFinalBlock();

                byte[] encrypted = msEncrypt.ToArray();
                return Convert.ToBase64String(encrypted);
            }
            catch
            {
                return "";
            }
            finally
            {
                myRijndael = null;
            }
        }

        public string Descriptografar(string texto)
        {
            var myRijndael = new RijndaelManaged();
            try
            {
                myRijndael.Padding = PaddingMode.Zeros;
                myRijndael.Mode = CipherMode.CBC;
                myRijndael.KeySize = 256;
                myRijndael.BlockSize = 256;

                byte[] key = System.Text.Encoding.ASCII.GetBytes(sKy);
                byte[] IV = System.Text.Encoding.ASCII.GetBytes(sIV);

                ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, IV);

                byte[] sEncrypted = Convert.FromBase64String(texto);
                byte[] fromEncrypt = new byte[sEncrypted.Length + 1];

                var msDecrypt = new MemoryStream(sEncrypted);
                var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                return System.Text.Encoding.ASCII.GetString(fromEncrypt);
            }
            catch
            {
                return "";
            }
            finally
            {
                myRijndael = null;
            }
        }
    }
}
