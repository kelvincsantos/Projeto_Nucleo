using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Nucleo.Base.Seguranca
{
    public class Criptografia
    {
        private string Chave = "Josue61".PadRight(32, 'X');


        public Criptografia()
        {
            if (!PegarChaveInterna())
            {

            }
        }

        public bool PegarChaveInterna()
        {
            try
            {
                //RegistryKey Registro = Registry.LocalMachine.OpenSubKey("NucleoSecurity", true);

                //if (Registro == null)
                //    Registro = Registry.LocalMachine.CreateSubKey("NucleoSecurity", true);


                //string ValorCapturado = Registro.GetValue("First").ToString();
                //if (string.IsNullOrWhiteSpace(ValorCapturado))
                //    Registro.SetValue("First", Chave);


                //Chave = ValorCapturado;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public string Codificar(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };

            value = value.Replace("\0", "");

            try
            {
                byte[] bytValue = Encoding.ASCII.GetBytes(value);
                byte[] bytKey = Encoding.ASCII.GetBytes(Chave);

                if (value == null || value.Length <= 0)
                    throw new ArgumentNullException("valor");
                if (bytKey == null || bytKey.Length <= 0)
                    throw new ArgumentNullException("chave");
                if (bytIV == null || bytIV.Length <= 0)
                    throw new ArgumentNullException("IV");

                byte[] encrypted;
                // Create an RijndaelManaged object
                // with the specified key and IV.
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = bytKey;
                    rijAlg.IV = bytIV;

                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {

                                //Write all data to the stream.
                                swEncrypt.Write(value);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream.
                return Convert.ToBase64String(encrypted);
            }
            catch (Exception)
            {
                //Assert.Error("Erro. " + "\n\r" + ex.StackTrace, ex, "Erro", false);
                return null;
            }
        }

        public string Decodificar(string value)
        {
            if (string.IsNullOrEmpty(value)) { return null; }

            byte[] bytIV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };



            try
            {
                byte[] bytDataToBeDecrypted = Convert.FromBase64String(value);
                byte[] bytDecryptionKey = Encoding.ASCII.GetBytes(Chave);

                if (bytDataToBeDecrypted == null || bytDataToBeDecrypted.Length <= 0)
                    throw new ArgumentNullException("Dado encriptado");
                if (bytDecryptionKey == null || bytDecryptionKey.Length <= 0)
                    throw new ArgumentNullException("Chave");
                if (bytIV == null || bytIV.Length <= 0)
                    throw new ArgumentNullException("IV");

                string result;
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = bytDecryptionKey;
                    rijAlg.IV = bytIV;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(bytDataToBeDecrypted))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                //Assert.Error("Erro. " + "\n\r" + ex.StackTrace, ex, "Erro", false);
                return null;
            }
        }
    }
}
