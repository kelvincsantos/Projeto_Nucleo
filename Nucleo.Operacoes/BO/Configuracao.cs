using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nucleo.Operacoes.BO
{
    public class Configuracao
    {
        public Nucleo.Base.SQL.SQL banco { get; set; }

        private ADO.Configuracao ADO;
        public Configuracao() 
        {
            ADO = new ADO.Configuracao();
        }
        public Configuracao(Nucleo.Base.SQL.SQL Banco)
        {
            this.banco = Banco;
            ADO = new ADO.Configuracao(banco);
        }

        public bool Inserir(Data.Configuracao e)
        {
            return ADO.InserirOuAlterar(Transformar(e));
        }

        public bool Inserir(Data.PropriedadeConfiguracao e)
        {
            return ADO.InserirOuAlterar(e);
        }

        public bool Inserir(Dictionary<string, string> e)
        {
            return ADO.InserirOuAlterar(e);
        }

        public List<Data.PropriedadeConfiguracao> Buscar()
        {
            return ADO.Buscar();
        }

        public Data.Configuracao BuscarConfiguracao()
        {
            return Transformar(ADO.Buscar());
        }

        public List<Data.PropriedadeConfiguracao> BuscarDoObjeto()
        {
            return TransformarVazio();   
        }

        private List<Data.PropriedadeConfiguracao> TransformarVazio()
        {
            List<Data.PropriedadeConfiguracao> parConfig = new List<Data.PropriedadeConfiguracao>();

            foreach (PropertyInfo info in typeof(Data.Configuracao).GetProperties().ToList())
            {
                parConfig.Add(new Data.PropriedadeConfiguracao() { 
                    Campo = info.Name,
                });
            }

            return parConfig;
        }

        private Dictionary<string, string> Transformar(Data.Configuracao e)
        {
            Dictionary<string, string> parConfig = new Dictionary<string, string>();


            foreach (PropertyInfo info in typeof(Data.Configuracao).GetProperties().ToList())
            {
                parConfig.Add(info.Name, info.GetValue(e).ToString());
            }


            return parConfig;
        }

        private Data.Configuracao Transformar(Dictionary<string, string> e)
        {
            Data.Configuracao config = new Data.Configuracao();

            foreach (PropertyInfo info in typeof(Data.Configuracao).GetProperties().ToList())
            {
                if (info.CanWrite)
                    info.SetValue(config, e.GetValueOrDefault(info.Name), null);
            }

            return config;
        }

        private Data.Configuracao Transformar(List<Data.PropriedadeConfiguracao> e)
        {
            Data.Configuracao config = new Data.Configuracao();

            foreach (PropertyInfo info in typeof(Data.Configuracao).GetProperties().ToList())
            {
                Data.PropriedadeConfiguracao prop = e.Where(x => x.Campo == info.Name).FirstOrDefault();

                if (info.CanWrite && prop != null)
                    info.SetValue(config, prop.Valor, null);
            }

            return config;
        }
    }
}
