using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class CommonController
    {
        public string Encrypt(string password)
        {
            try
            {
                string encrypted = "";
                string EncryptionKey = "OurSecretKey";
                byte[] clearBytes = Encoding.Unicode.GetBytes(password);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        encrypted = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return encrypted;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Decrypt(string password)
        {
            try
            {
                string decrypted = "";
                string EncryptionKey = "OurSecretKey";
                byte[] cipherBytes = Convert.FromBase64String(password);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        decrypted = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return decrypted;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}