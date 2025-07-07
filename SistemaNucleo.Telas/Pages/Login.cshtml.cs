using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SistemaNucleo.Telas.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Username == "admin" && Password == "1234") // Exemplo simples
            {
                // Cria o cookie de autentica��o
                Response.Cookies.Append("Auth", "authenticated", new CookieOptions
                {
                    HttpOnly = true,
                    //Secure = true, // Use apenas em conex�es HTTPS
                    Expires = DateTimeOffset.UtcNow.AddHours(1) // Expira em 1 hora
                });

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Usu�rio ou senha inv�lidos.");
            return Page();
        }
    }
}
