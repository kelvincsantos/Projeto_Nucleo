using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaNucleo.Telas.Pages.Cadastro
{
    public class MenuModel : PageModel
    {
        private readonly ILogger<MenuModel> _logger;

        public MenuModel(ILogger<MenuModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // Verifica se o cookie de autenticação existe
            var authCookie = Request.Cookies["Auth"];
            if (string.IsNullOrEmpty(authCookie))
            {
                // Redireciona para a página de login se o cookie não existir
                return RedirectToPage("/Login");
            }

            // Caso o cookie exista, continue carregando a página
            return Page();
        }
    }
}
