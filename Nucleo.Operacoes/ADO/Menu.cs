using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.ADO
{
    public class Menu
    {

        public Nucleo.Base.SQL.SQL banco { get; set; }

        public Menu() { }
        public Menu(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
        }

        public List<Data.Menu> BuscarMenus(Data.Menu? menu)
        {
            List<Data.Menu> Menus = new List<Data.Menu>();


            if (menu != null)
            {
                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = "/Usuarios",
                    Nome = "Usuários",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = "/Produtos",
                    Nome = "Produtos",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = "/Clientes",
                    Nome = "Clientes",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = "/PlanoContas",
                    Nome = "Plano de Contas",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                return Menus;
            }
            else
            {

              
                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = string.Empty,
                    Nome = "Cadastros",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = string.Empty,
                    Nome = "Relatórios",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = string.Empty,
                    Nome = "Financeiro",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                Menus.Add(new Data.Menu()
                {
                    ID = Guid.NewGuid().ToString(),
                    Navegacao = string.Empty,
                    Nome = "Configurações",
                    IDMenuPai = string.Empty,
                    UsuarioPermitido = true
                });

                return Menus;
            }
        }
    }
}
