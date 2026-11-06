using Microsoft.AspNetCore.Mvc;
using System.Text;
using ADO = Nucleo.Operacoes.ADO;
using Negocio = Nucleo.API.Negocio;

namespace Nucleo.API.Controllers.Cadastro
{
    [ApiController]
    [Route("/api/cadastro/cliente")]
    public class ClienteController : ControllerBase
    {
       
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCliente")]
        public HttpResponseMessage Get()
        {
            List<Data.Usuario> usuarios= new List<Data.Usuario>();// = new ADO.Usuario().BuscarTodos();

            string json = new Base.Comum.Conversor.Json<List<Data.Usuario>>().Serializar(usuarios);
             
            return Comum.Resposta.OK(json);
        }

        [HttpPost(Name = "PostCliente")]
        public HttpResponseMessage Post(Negocio.Request.CadastrarCliente cliente)
        {
            List<Data.Usuario> usuarios = new List<Data.Usuario>();// = new ADO.Usuario().BuscarTodos();

            string json = new Base.Comum.Conversor.Json<List<Data.Usuario>>().Serializar(usuarios);

            return Comum.Resposta.OK(json);
        }
    }
}
