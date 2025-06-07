using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.Aplicacao
{
    public class Log
    {
        List<string> logList = new List<string>();

        public bool gravar { get; set; }

        private string nomeArquivo = "logErro.err";

        public Log()
        {
            gravar = false;
        }

        public void Iniciar()
        {
            logList.Add(string.Concat("----- INICIA ", new StackFrame(1).GetMethod(), "-----"));
        }

        public void Finalizar()
        {
            logList.Add(string.Concat("----- FINALIZA ", new StackFrame(1).GetMethod(), "-----"));

            if (gravar)
                Gravar();
        }

        private void Gravar()
        {
            nomeArquivo = string.Concat(DateTime.Now.Day
                , DateTime.Now.Month
                , DateTime.Now.Year
                , "_"
                , DateTime.Now.Minute
                , DateTime.Now.Hour
                , "_"
                , nomeArquivo);

            if (!File.Exists(nomeArquivo)) File.Create(nomeArquivo);

            StreamWriter sw = new StreamWriter(nomeArquivo);

            foreach (string message in logList)
            {
                sw.WriteLine(message);
            }

            sw.Close();
        }

        public void Detalhe(string mensagem)
        {
            logList.Add(string.Concat(DateTime.Now.ToLongDateString(), "|", mensagem));
        }

        public void Erro(string mensagem, Exception ex)
        {
            gravar = true;
            logList.Add(string.Concat(DateTime.Now.ToLongDateString(), "|Exceção:", mensagem, " >>> ", TraduzirEx(ex)));
        }

        public void Teste(string mensagem)
        {
            gravar = true;
            logList.Add(string.Concat(DateTime.Now.ToLongDateString(), "|", mensagem));
        }

        public string TraduzirEx(Exception ex)
        {
            string log = " # " + ex.Message;

            Exception inner = ex.InnerException;

            while (inner != null)
            {
                log = string.Concat(log, "| InnerException: ", inner.Message);

                inner = inner.InnerException;
            }

            return log;
        }
    }
}
