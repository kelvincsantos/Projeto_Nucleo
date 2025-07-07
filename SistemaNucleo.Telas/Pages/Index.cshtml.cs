using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaNucleo.Telas.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
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
