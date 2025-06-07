namespace Nucleo.API
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class Ambiente
    {
        public static Comum.Arquivos Arquivos { get; set; }
        public static DadosConexao conexao { get; set; }


        public Ambiente()
        {
            Arquivos = new Comum.Arquivos();
            conexao = new DadosConexao();
        }

        public partial class DadosConexao
        {
            public string Servidor { get; set; }
            public string Banco { get; set; }
            public string Senha { get; set; }
            public string Usuario { get; set; }
        }
    }
}
