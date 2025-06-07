using Nucleo.Base.Log;
using Nucleo.Base.SQL.Operacoes;
using Nucleo.Data.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Operacoes.BO
{
    public class EstruturaDatabase
    {
        private ADO.EstruturaDatabase DAO { get; set; }

        public Nucleo.Base.SQL.SQL Local { get; set; }

        List<TabelaDB> tabelas = new List<TabelaDB>();
        List<RestricaoDB.FK> chavesFK = new List<RestricaoDB.FK>();
        List<RestricaoDB.Indices> indices = new List<RestricaoDB.Indices>();


        public EstruturaDatabase()
        {
            DAO = new ADO.EstruturaDatabase();
        }

        public EstruturaDatabase(Nucleo.Base.SQL.SQL banco)
        {
            DAO = new ADO.EstruturaDatabase(banco);
        }

        public void Atualizar(Nucleo.Base.SQL.SQL instancia)
        {
            Rastreamento.Iniciar(this);

            Local = instancia;
            AtualizarEstrutura();
            AtualizarChaves();
            AtualizarIndices();

            Rastreamento.Finalizar(this);
        }

        private void AtualizarEstrutura()
        {
            Rastreamento.Iniciar(this);

            try
            {
                List<TabelaDB> Tabelas = DAO.BuscarTabelasNovas();
                foreach (TabelaDB tabela in Tabelas)
                {
                    tabela.AdicionarChaves(DAO.BuscarChavesPorTabela(tabela));

                    Local.Executar(tabela.Criar());
                }

                Tabelas = DAO.BuscarTabelasAlteradas();

                foreach (TabelaDB tabela in Tabelas)
                {
                    List<string> alteracoes = tabela.ColunasAlteradas();

                    foreach (string alteracao in alteracoes)
                    {
                        Local.Executar(alteracao);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            Rastreamento.Finalizar(this);
        }

        private void AtualizarChaves()
        {
            Rastreamento.Iniciar(this);

            try
            {
                List<RestricaoDB.FK> chaves = DAO.BuscarChavesAlteradas();

                foreach (RestricaoDB.FK Chave in chaves)
                {
                    List<string> alteracoes = Chave.AlteracaoDaTabela();

                    try
                    {
                        Local.AbrirTransacao();
                        foreach (string alteracao in alteracoes)
                        {
                            Local.Executar(alteracao);
                        }

                        Local.ConfirmarTransacao();
                    }
                    catch (Exception ex)
                    {
                        Local.ReverterTransacao();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            Rastreamento.Finalizar(this);
        }

        private void AtualizarIndices()
        {
            Rastreamento.Iniciar(this);

            try
            {
                List<RestricaoDB.Indices> Novos = DAO.BuscarIndicesNovos();
                foreach (RestricaoDB.Indices indice in Novos)
                {
                    List<string> execucoes = indice.Criar();

                    foreach (string execucao in execucoes)
                    {
                        Local.Executar(execucao);
                    }
                }

                List<RestricaoDB.Indices> indices = DAO.BuscarIndicesNovos();

            }
            catch (Exception ex)
            {

                throw;
            }
        
            Rastreamento.Finalizar(this);
        }

        public void AtualizarPorScript(Nucleo.Base.SQL.SQL instancia)
        {
            Rastreamento.Iniciar(this);

            Local = instancia;
            List<string> scripts = BuscarScripts();

            if (scripts.Count > 0)
                scripts.ForEach(x => ExecutarScript(x));

            Rastreamento.Finalizar(this);
        }

        private List<string> BuscarScripts()
        {
            Rastreamento.Iniciar(this);

            string caminhoBase = Path.Combine(AppContext.BaseDirectory, "DB");
            List<string> strings = new List<string>();
            try
            {
                
                if (!Directory.Exists(caminhoBase))
                    return strings;

                Rastreamento.Escrever($"diretório existente: {caminhoBase}");

                string caminhoDDL = Path.Combine(caminhoBase, "DDL");
                string caminhoDML = Path.Combine(caminhoBase, "DML");

                if (!Directory.Exists(caminhoDDL) && !Directory.Exists(caminhoDML))
                    return strings;

                Rastreamento.Escrever($"diretório existente: {caminhoDDL} ou {caminhoDML}");

                List<string> DDL = Directory.GetFiles(caminhoDDL, "*.sql").ToList();
                
                Rastreamento.Escrever($"Arquivos DDL encontrados: {DDL.Count} ");

                if (DDL.Count > 0)
                    strings.AddRange(DDL);

                List<string> DML = Directory.GetFiles(caminhoDML, "*.sql").ToList();

                Rastreamento.Escrever($"Arquivos DML encontrados: {DML.Count} ");

                if (DML.Count > 0) 
                    strings.AddRange(DML);
            }
            catch (Exception ex)
            {
                Rastreamento.Erro(ex, $"Erro ao buscar os scripts de SQL na pasta {caminhoBase}.");
            }

            Rastreamento.Finalizar(this);
            return strings;
        }

        private bool ExecutarScript(string script)
        {
            Rastreamento.Iniciar(this);
            bool status = true;
            try
            {
                Rastreamento.Escrever($"Script em execução: {script}");

                Local.Executar(script);
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                Rastreamento.Erro(ex, "Erro ao executar script de atualização do banco de dados.");
            }

            Rastreamento.Finalizar(this);
            return status;
        }
    }
}
