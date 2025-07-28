using Microsoft.AspNetCore.Mvc;
using System.Text;
using ADO = Nucleo.Operacoes.ADO;

namespace Nucleo.API.Controllers.Cadastro
{
    [ApiController]
    [Route("/api/cadastro/usuario")]
    public class UsuarioController : ControllerBase
    {
       
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUsuario")]
        public HttpResponseMessage Get()
        {
            List<Data.Usuario> usuarios= new List<Data.Usuario>();// = new ADO.Usuario().BuscarTodos();

            string json = new Base.Comum.Conversor.Json<List<Data.Usuario>>().Serializar(usuarios);
             
            return Comum.Resposta.OK(json);
        }
    }
}
