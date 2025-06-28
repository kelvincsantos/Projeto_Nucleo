using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text;
//using RestSharp;
using Nucleo.API.Core.Aplicacao;
using System.Diagnostics.CodeAnalysis;

namespace Nucleo.API.Core
{
    public class Interface
    {
        private string   baseURL { get; set; }
        public Interface(string BaseURL) 
        {
            this.baseURL = BaseURL;
        }

        public async Task<Saida?> CallAsync_HTTPClient(Entrada e)
        {
            HttpClient client;
            try
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                if (e.Headers != null && e.Headers.Count > 0)
                    foreach (KeyValuePair<string, string> item in e.Headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                string endPoint = e.EndPointComParametros();

                HttpResponseMessage? httpResponse = null;
                if (e.Metodo == Metodo.POST)
                {
                    var content = new StringContent(e.Conteudo, Encoding.UTF8, "application/json");
                    httpResponse = await client.PostAsync(endPoint, content);
                }
                else if (e.Metodo == Metodo.GET)
                    httpResponse = await client.GetAsync(endPoint);
                else if (e.Metodo == Metodo.PUT)
                    httpResponse = await client.PutAsync(endPoint, null);

                if (httpResponse == null)
                    return null;

                string result = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.PreconditionFailed)
                {   
                    return new Saida()
                    {
                        sucesso = true,
                        Conteudo = result,
                    };
                }
                else
                {
                    return new Saida()
                    {
                        sucesso = false,
                        Conteudo = result,
                        Erro = new Saida._Erro()
                        {
                            Codigo = (int)httpResponse.StatusCode,
                            Erro = string.Concat("Erro no EndPoint:", e.EndPoint),
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                return TratarExcecao(ex, e);
            }
        }

        //public Saida Call_Rest(Entrada e)
        //{
        //    try
        //    {
        //        string endPoint = e.EndPointComParametros();

        //        RestClient rest = new RestClient(String.Concat(baseURL, endPoint));
        //        RestRequest request = new RestRequest();
        //        request.Method = (Method)e.Metodo;

        //        if (e.Headers != null && e.Headers.Count > 0)
        //            foreach (KeyValuePair<string, string> item in e.Headers)
        //            {
        //                request.AddHeader(item.Key, item.Value);
        //            }


        //        if (e.Metodo == Metodo.POST)
        //            request.AddParameter("application/json", e.Conteudo, ParameterType.RequestBody);

        //        RestResponse response = rest.Execute(request);

        //        return new Saida()
        //        {
        //            Conteudo = response.Content,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return TratarExcecao(ex, e);
        //    }
            
        //}

        private Saida TratarExcecao(Exception ex, Entrada e)
        {
            return new Saida()
            {
                Erro = new Saida._Erro()
                {
                    Codigo = -1,
                    Erro = string.Concat("Erro na comunicação com a API (", e.EndPoint, "): "),
                    excecao = ex,
                }
            };
        }
    }
}