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

        public bool GerarArquivoPadrao()
        {
            string Arquivo = "C:\\ETQ Padrao\\LoteEtiquetas.csv";

            
            MsgBox("O arquivo excel padrão será salvo em C:\BoxPDV Sistemas\Parceiros\ParceirosBOXPDV.csv.", MsgBoxStyle.Information, "Ok")
            If Not IO.Directory.Exists("C:\BoxPDV Sistemas\Parceiros") Then
                IO.Directory.CreateDirectory("C:\BoxPDV Sistemas\Parceiros")
            End If

            Dim sw As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(vArquivo, False)

            sw.WriteLine("Nome;NomeFantasia;CNPJ;InscEst;CPF;RG;CEP;Endereco;Numero;Complemento;Bairro;Cidade;UF;DDD;Telefone;EMail;CodVendedor;ComissaoVendedor;CondicaoPagamento;ValorCredito;Codigo;Perfil;")
            sw.WriteLine("    ;            ;    ;       ;   ;      ;        ;      ;           ;      ;      ;  ;   ;        ;     ;           ;                ;")

            sw.Close()

            MsgBox("Exportação efetuada com sucesso.", MsgBoxStyle.Information, "Ok")
        }
    }
}
