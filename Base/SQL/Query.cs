using System;
using System.Collections.Generic;
using System.Text;
using Nucleo.Base.Enumeradores;

namespace Nucleo.Base.SQL
{
    public class Query
    {
        public Operacoes.Selecionar Selecionar { get; set; }
        public Operacoes.Inserir Inserir { get; set; }
        public Operacoes.Alterar Alterar { get; set; }
        public Operacoes.Deletar Deletar { get; set; }



        public Query()
        {
            Selecionar = new Operacoes.Selecionar();
            Inserir = new Operacoes.Inserir();
            Alterar = new Operacoes.Alterar();
            Deletar = new Operacoes.Deletar();
        }


        public static void Preparar(Enumeradores.SQL.Operacoes operacao)
        {
            if (operacao == Enumeradores.SQL.Operacoes.Inserir)
                PrepararInsert();
            else if (operacao == Enumeradores.SQL.Operacoes.Alterar)
                PrepararUpdate();
            else if (operacao == Enumeradores.SQL.Operacoes.Deletar)
                PrepararDelete();
            else if (operacao == Enumeradores.SQL.Operacoes.Selecionar)
                PrepararSelect();
        }

        private static void PrepararInsert()
        {

        }

        private static void PrepararSelect()
        {

        }

        private static void PrepararUpdate()
        {

        }

        private static void PrepararDelete()
        {

        }

    }
}
