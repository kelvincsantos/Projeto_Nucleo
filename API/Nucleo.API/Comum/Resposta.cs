using System.Text;
using static Nucleo.Base.Comum.Conversor;

namespace Nucleo.API.Comum
{
    public static class Resposta
    {

        public static HttpResponseMessage OK(string json)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }

        public static HttpResponseMessage Erro(Exception ex)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(ex.Message, Encoding.UTF8, "application/json"),
            };
        }

        public static HttpResponseMessage ErroTratado(string erro)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent(erro, Encoding.UTF8, "application/json"),
            };
        }
    }
}
