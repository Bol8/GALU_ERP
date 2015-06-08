using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GALU_ERP.Security
{
    public class Cryptography
    {
        string key = "9fb|P=AN,Eh|BH^s:[F=>!f3H0C|HrdTuiCBV-%5oK^}~giQ}W";

        public Cryptography(string newKey)
        {
            key = newKey;
        }

        public Cryptography()
        {
        }

        public string encodeData(string data)
        {
            try
            {
                byte[] keyArray; // Array donde se guarda la llave de cifrado
                byte[] dataArray = UTF8Encoding.UTF8.GetBytes(data); // Array donde se guardan los datos a cifrar
                byte[] returnDataArray; // Array donde se guarda los datos cifrados

                // Ciframos utilizando el Algoritmo MD5
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                md5.Clear();

                // Ciframos utilizando el Algoritmo 3DES
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = keyArray;
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform converter = tripleDES.CreateEncryptor();
                returnDataArray = converter.TransformFinalBlock(dataArray, 0, dataArray.Length);
                tripleDES.Clear();

                return Convert.ToBase64String(returnDataArray, 0, returnDataArray.Length);
            }
            catch
            {
                return "";
            }


        }

        public string decodeData(string data)
        {
            try
            {
                byte[] keyArray; // Array donde se guarda la llave de cifrado
                byte[] dataArray = Convert.FromBase64String(data); // Array donde se guardan los datos a descifrar
                byte[] returnDataArray; // Array donde se guarda los datos descifrados

                // Ciframos utilizando el Algoritmo MD5
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                md5.Clear();

                // Ciframos utilizando el Algoritmo 3DES
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = keyArray;
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform converter = tripleDES.CreateDecryptor();
                returnDataArray = converter.TransformFinalBlock(dataArray, 0, dataArray.Length);
                tripleDES.Clear();

                return UTF8Encoding.UTF8.GetString(returnDataArray);
            }
            catch
            {
                return "";
            }
        }

    }
}