using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssinadorCertificado
{
    class Program
    {
        static void Main(string[] args)
        {
            // To idendify the Smart Card CryptoGraphic Providers on your
            // computer, use the Microsoft Registry Editor (Regedit.exe).
            // The available Smart Card CryptoGraphic Providers are listed
            // in HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Defaults\Provider.

            // Create a new CspParameters object that identifies a 
            // Smart Card CryptoGraphic Provider.
            // The 1st parameter comes from HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Defaults\Provider Types.
            // The 2nd parameter comes from HKEY_LOCAL_MACHINE\Software\Microsoft\Cryptography\Defaults\Provider.

            CspParameters csp = new CspParameters(1, "eToken Base Cryptographic Provider");

            csp.Flags = CspProviderFlags.UseDefaultKeyContainer;

            // Initialize an RSACryptoServiceProvider object using
            // the CspParameters object.

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp);

            // Create some data to sign.
            byte[] data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };     // CNPJs vinculados

            Console.WriteLine("Data     : " + BitConverter.ToString(data));

            // Sign the data using the Smart Card CryptoGraphic Provider.
            byte[] sig = rsa.SignData(data, "SHA256");

            Console.WriteLine("Signature: " + BitConverter.ToString(sig));

            string base64sign = Convert.ToBase64String(sig);

            Console.WriteLine("Base64   : " + base64sign);
            Console.WriteLine("Tamanho  : " + base64sign.Length.ToString());

            // Verify the data using the Smart Card CryptoGraphic Provider.
            bool verified = rsa.VerifyData(data, "SHA256", sig);

            Console.WriteLine("Verified : " + verified);
        }

    }
}
