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
                RegistryKey Registro = Registry.LocalMachine.OpenSubKey("NucleoSecurity", true);

                if (Registro == null)
                    Registro = Registry.LocalMachine.CreateSubKey("NucleoSecurity", true);


                string ValorCapturado = Registro.GetValue("First").ToString();
                if (string.IsNullOrWhiteSpace(ValorCapturado))
                    Registro.SetValue("First", Chave);


                Chave = ValorCapturado;
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

                using (MemoryStream objMemoryStream = new MemoryStream())
                {
                    RijndaelManaged objRijndaelManaged = new RijndaelManaged();

                    using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(bytValue, 0, bytValue.Length);
                        objCryptoStream.FlushFinalBlock();

                        byte[] bytEncoded = objMemoryStream.ToArray();

                        return Convert.ToBase64String(bytEncoded);
                    }
                }
            }
            catch (Exception ex)
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

                using (MemoryStream objMemoryStream = new MemoryStream(bytDataToBeDecrypted))
                {
                    RijndaelManaged objRijndaelManaged = new RijndaelManaged();
                    using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), CryptoStreamMode.Read))
                    {
                        byte[] bytEncoded = new byte[objMemoryStream.Length];

                        objCryptoStream.Read(bytEncoded, 0, Convert.ToInt32(objMemoryStream.Length));

                        return Encoding.ASCII.GetString(bytEncoded).Replace("\0", "");
                    }
                }
            }
            catch (Exception ex)
            {
                //Assert.Error("Erro. " + "\n\r" + ex.StackTrace, ex, "Erro", false);
                return null;
            }
        }
    }
}
