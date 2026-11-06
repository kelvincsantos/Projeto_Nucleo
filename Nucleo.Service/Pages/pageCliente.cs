using Nucleo.Service.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eAPI = Nucleo.API.Core.Externas;
using BO = Nucleo.Operacoes.BO;
using Model = Nucleo.Data;

namespace Nucleo.Service.Pages
{
    public class pageCliente : IBasePageServico
    {
        private BO.Ticker BO;


        public void Cadastrar(Model.Cliente cliente)
        {
        }

        public void Carregar()
        {

        }
    }
}
