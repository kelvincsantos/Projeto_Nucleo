using Nucleo.Service.Comum;
using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Service.Comum
{
    public class Controller
    {
        private const string sNameSpace = "Nucleo.Service.Servicos";
        public void Executar(List<string> nomesDasClasses)
        {
            foreach (var nomeClasse in nomesDasClasses)
            {
                string nomeClasseCompleto = string.Concat(sNameSpace, ".", nomeClasse);

                Type? tipo = Type.GetType(nomeClasseCompleto);
                if (tipo != null)
                {
                    object? objeto = Activator.CreateInstance((Type)tipo);

                    if (objeto != null)
                    {
                        IBaseServico instancia = (IBaseServico)objeto;

                        instancia.Iniciar();
                    }
                    else
                        Console.WriteLine("Instância da classe não identificada");
                }
                else
                    Console.WriteLine($"Classe '{nomeClasse}' não encontrada");
            }
        }
    }
}