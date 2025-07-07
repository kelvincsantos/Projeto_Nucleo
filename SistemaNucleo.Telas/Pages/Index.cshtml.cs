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
        // Verifica se o cookie de autentica��o existe
        var authCookie = Request.Cookies["Auth"];
        if (string.IsNullOrEmpty(authCookie))
        {
            // Redireciona para a p�gina de login se o cookie n�o existir
            return RedirectToPage("/Login");
        }

        // Caso o cookie exista, continue carregando a p�gina
        return Page();
    }
}
