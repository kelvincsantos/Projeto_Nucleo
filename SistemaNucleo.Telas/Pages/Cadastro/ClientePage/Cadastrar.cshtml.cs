using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Data = Nucleo.Data;
using Serv = Nucleo.Service;

namespace SistemaNucleo.Telas.Pages.Cadastro.ClientePage
{
    public class CadastrarModel : PageModel
    {
        Serv.Pages.pageCliente servCliente = null;

        [BindProperty]
        public Data.Cliente cliente { get; set; }
        public CadastrarModel(Serv.Comum.IBasePageServico page)
        {
            if (page.GetType() == typeof(Serv.Pages.pageCliente))
                this.servCliente = (Serv.Pages.pageCliente)page;
        }

        [BindProperty]
        public Data.Cliente Cliente { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            servCliente.Cadastrar(cliente);

            return RedirectToPage("Index");
        }

    }
}
