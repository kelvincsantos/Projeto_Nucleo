using DocumentFormat.OpenXml.Office2019.Excel.ThreadedComments;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Base.Seguranca
{
    public static class ChavesSistema
    {

        public static bool Registrar(string propriedade, string valor)
        {
            try
            {
                RegistryKey raiz = AbrirRegistroPrincipal();
                
                raiz.SetValue(propriedade, new Criptografia().Codificar(valor));

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string Buscar(string propriedade)
        {
            try
            {
                RegistryKey raiz = AbrirRegistroPrincipal();

                if (raiz == null)
                    return string.Empty;

                return new Criptografia().Decodificar(raiz.GetValue(propriedade)?.ToString());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        private static RegistryKey AbrirRegistroPrincipal()
        {
            RegistryKey? RegistroRaiz = Registry.Users.OpenSubKey(".DEFAULT\\Software", true);

            RegistryKey principal = RegistroRaiz?.OpenSubKey("Nucleo", true);

            if (principal == null)
                principal = RegistroRaiz.CreateSubKey("Nucleo", true);


            return principal;
        }
    }
}
