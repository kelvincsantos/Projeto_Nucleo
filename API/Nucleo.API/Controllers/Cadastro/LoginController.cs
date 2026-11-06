using Microsoft.AspNetCore.Mvc;
using System.Text;
using ADO = Nucleo.Operacoes.ADO;

namespace Nucleo.API.Controllers.Cadastro
{
    [ApiController]
    [Route("/api/login")]
    public class LoginController : ControllerBase
    {
       
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostLogin")]
        public HttpResponseMessage Post()
        {
            List<Data.Usuario> usuarios= new List<Data.Usuario>();// = new ADO.Usuario().BuscarTodos();

            string json = new Base.Comum.Conversor.Json<List<Data.Usuario>>().Serializar(usuarios);
             
            return Comum.Resposta.OK(json);
        }
    }
}
