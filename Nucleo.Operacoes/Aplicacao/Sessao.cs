using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Operacoes.Aplicacao
{
    public static class Sessao
    {
        public static Data.Usuario Usuario
        {
            get => Central.Dados.UsuarioLogado;
        }

        public static Data.Empresa Empresa
        {
            get => Central.Dados.Empresa;
        }

        public static Data.Configuracao Configuracao
        {
            get => Central.Dados.Configuracao;
        }
    }
}
