using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualBasic;
using Nucleo.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nucleo.View.Views.Tela
{
    public class GerarEtiqueta
    {

        public List<Etiqueta> CarregarLista(string arquivo)
        {
            return new List<Etiqueta>();
        }

        public string GerarArquivoPadrao()
        {
            try
            {
                string Arquivo = "C:\\ETQ Padrao\\LoteEtiquetas.csv";


                if (!Directory.Exists("C:\\ETQ Padrao"))
                    Directory.CreateDirectory("C:\\ETQ Padrao");

                StreamWriter sw = new StreamWriter(Arquivo, false);

                sw.WriteLine("NumeroIdentificacao;NumeroCertificado;DataCalibracao;ProximaCalibracao;DiretorioLaudo;");
                sw.WriteLine("                   ;                 ;              ;                 ;              ;");

                sw.Close();

                return Arquivo;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }
    }
}
