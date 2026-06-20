using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace LibNF65
{


public class Criptografia
    {
        private string sKy = "chavede0criptografia9nascomercio"; // 32 chr shared ascii string (32 * 8 = 256 bit)
        private string sIV = "vetorde9criptografia0nascomercio"; // 32 chr shared ascii string (32 * 8 = 256 bit)

        public string Criptografar(string texto)
        {
            RijndaelManaged myRijndael = new RijndaelManaged();
            try
            {
                myRijndael.Padding = PaddingMode.Zeros;
                myRijndael.Mode = CipherMode.CBC;
                myRijndael.KeySize = 256;
                myRijndael.BlockSize = 256;

                byte[] key = Encoding.ASCII.GetBytes(sKy);
                byte[] IV = Encoding.ASCII.GetBytes(sIV);
                byte[] toEncrypt = Encoding.ASCII.GetBytes(texto);

                ICryptoTransform encryptor = myRijndael.CreateEncryptor(key, IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                    csEncrypt.FlushFinalBlock();
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                myRijndael.Dispose();
                myRijndael = null;
            }
        }

        public string Descriptografar(string texto)
        {
            RijndaelManaged myRijndael = new RijndaelManaged();
            try
            {
                myRijndael.Padding = PaddingMode.Zeros;
                myRijndael.Mode = CipherMode.CBC;
                myRijndael.KeySize = 256;
                myRijndael.BlockSize = 256;

                byte[] key = Encoding.ASCII.GetBytes(sKy);
                byte[] IV = Encoding.ASCII.GetBytes(sIV);
                byte[] sEncrypted = Convert.FromBase64String(texto);
                byte[] fromEncrypt = new byte[sEncrypted.Length];

                ICryptoTransform decryptor = myRijndael.CreateDecryptor(key, IV);

                using (MemoryStream msDecrypt = new MemoryStream(sEncrypted))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    return Encoding.ASCII.GetString(fromEncrypt);
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                myRijndael.Dispose();
                myRijndael = null;
            }
        }
    }
}
