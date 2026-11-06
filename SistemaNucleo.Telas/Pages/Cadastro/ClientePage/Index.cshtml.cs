using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace SistemaNucleo.Telas.Pages.Cadastro.Cliente
{
    public class IndexModel : PageModel
    {
        public class IndexModel : PageModel
        {
            private readonly AppDbContext _context;
            public IndexModel(AppDbContext context) => _context = context;

            public IList<Cliente> Clientes { get; set; }

            public void OnGet()
            {
                Clientes = _context.Clientes.ToList();
            }
        }

    }
}
