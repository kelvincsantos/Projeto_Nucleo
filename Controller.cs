using System;
using System.Collections.Generic;
using System.Reflection;

public class ClasseA
{
    public void Iniciar() => Console.WriteLine("ClasseA iniciada");
}

public class ClasseB
{
    public void Iniciar() => Console.WriteLine("ClasseB iniciada");
}

public class Controller
{
    public void Executar(List<string> nomesDasClasses)
    {
        foreach (var nomeClasse in nomesDasClasses)
        {
            Type tipo = Type.GetType(nomeClasse);
            if (tipo != null)
            {
                object instancia = Activator.CreateInstance(tipo);
                MethodInfo metodo = tipo.GetMethod("Iniciar");
                if (metodo != null)
                {
                    metodo.Invoke(instancia, null);
                }
                else
                {
                    Console.WriteLine("Método 'Iniciar' não encontrado em nomeClasse");
                
            else
            
                Console.WriteLine("Classe '{nomeClasse}' não encontrada");
            }
        }
    }
}