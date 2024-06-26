using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Base.SQL
{
    public class Tabelas
    {
        public SQL Banco { get; set; }

        public Tabelas(SQL banco)
        {
            Banco = banco;
        }

        public void CriarEtiquetas()
        {
            string Query = string.Empty;
            Query += "	CREATE TABLE Etiquetas(								\n";
            Query += "		ID varchar(50) PRIMARY KEY NOT NULL,			\n";
            Query += "		DataCalibracao Date NULL,						\n";
            Query += "		ProximaCalibracao Date NULL,					\n";
            Query += "		NumeroCertificado varchar(100) NOT NULL,		\n";
            Query += "		DiretorioLaudo varchar(500) NULL,				\n";
            Query += "		NumeroIdentificacao varchar(100) NULL			\n";
            Query += "	)													\n";

            Banco.Executar(Query);
        }

        public void CriarFilaImpressao()
        {
            string Query = string.Empty;
            Query += "	CREATE TABLE FilaImpressao(						\n";
            Query += "		ID varchar(50) PRIMARY KEY NOT NULL,		\n";
            Query += "		Criacao Date NOT NULL,					    \n";
            Query += "		Impressao Date NULL,						\n";
            Query += "		CodigoEtiqueta varchar(50) NOT NULL,		\n";
            Query += "		Concluido bit NULL,                 		\n";
            Query += "		Erro varchar(500) NULL						\n";
            Query += "	)												\n";

            Banco.Executar(Query);
        }

        public void CriarConfiguracao()
        {
            string Query = string.Empty;
            Query += "	CREATE TABLE Configuracao(						\n";
            Query += "		ID varchar(50) PRIMARY KEY NOT NULL,		\n";
            Query += "		Campo varchar(200) NOT NULL,			    \n";
            Query += "		Valor varchar(200) NOT NULL 				\n";
            Query += "	)												\n";

            Banco.Executar(Query);
        }
    }
}
