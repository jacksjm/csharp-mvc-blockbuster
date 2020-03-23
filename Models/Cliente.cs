using System;
using System.Collections.Generic;
using Repositories;
using Controllers;

namespace Models {
    public class Cliente {
        /* 
            Getters and Setters 
        */
        /// <value>Get and Set the value of idCliente</value>
        public int IdCliente { get; set; }
        /// <value>Get and Set the value of nome</value>
        public string Nome { get; set; }
        /// <value>Get and Set the value of dtNasc</value>
        public DateTime DtNasc { get; set; }
        /// <value>Get and Set the value of cpf</value>
        public string Cpf { get; set; }
        /// <value>Get and Set the value of dias</value>
        public int Dias { get; set; }
        /// <value>Get and Set the value of locacoes</value>
        public List<Locacao> Locacoes { get; set; }

        /// <summary>Constructor to Cliente object.</summary>
        public Cliente (string nome, DateTime dtNasc, string cpf, int dias) {
            IdCliente = RepositoryCliente.GetId();
            Nome = nome;
            DtNasc = dtNasc;
            Cpf = cpf;
            Dias = dias;
            Locacoes = new List<Locacao> ();

            RepositoryCliente.AddCliente(this);
        }
        
        /// <summary>This method insert a new movie rental for the customer.</summary>
        /// <param name="locacao">The rental object.</param>
        public void InserirLocacao (Locacao locacao) {
            Locacoes.Add (locacao);
        }

        /// <sumary>This method find a customer.</sumary>
        public static Cliente GetCliente(int idCliente){
            return RepositoryCliente.Clientes().Find (cliente => cliente.IdCliente == idCliente);
        }

        /// <sumary>This method find return all customers.</sumary>
        public static List<Cliente> GetClientes(){
            return RepositoryCliente.Clientes();
        }

        /// <sumary>This method determines the string convertion.</sumary>
        public string ToString (bool simple = false) {
            if (simple) {
                string retorno = $"Id: {IdCliente} - Nome: {Nome}\n" +
                    "   Locações: \n";
                if (Locacoes.Count > 0) {
                    Locacoes.ForEach (
                        locacao => retorno += $"    Id: {locacao.IdLocacao} - " +
                        $"Data: {locacao.DtLocacao} - " +
                        $"Data de Devolução: {LocacaoController.GetDataDevolucao(locacao)}\n"
                    );
                } else {
                    retorno += "    Não há locações";
                }

                return retorno;
            }

            string dtNasc = this.DtNasc.ToString("dd/MM/yyyy");

            return $"Nome: {Nome}\n" +
                $"Data de Nasciment: {dtNasc}\n" +
                $"Qtd de Filmes: {ClienteController.GetQtdFilmes(this)}";
        }

        /// <sumary>This method import customers and rental on the database.</sumary>
        public static void Importar(){
            Cliente cliente;
            Locacao locacao;

            /* Generate costumers*/
            cliente = new Cliente (
                "Gabriel João Caio dos Santos",
                new DateTime (1953, 12, 17),
                "800.404.403-46",
                10
            );
            locacao = new Locacao (
                cliente,
                DateTime.Now.AddDays (-5)
            );
            locacao.InserirFilme (Filme.GetFilme(1));
            locacao.InserirFilme (Filme.GetFilme(3));
            
            cliente = new Cliente (
                "Eduarda Isabela Raimunda Ramos",
                new DateTime (1978, 11, 17),
                "296.918.247-52",
                15
            );
            locacao = new Locacao (
                cliente,
                DateTime.Now.AddDays (-8)
            );
            locacao.InserirFilme (Filme.GetFilme(5));
            locacao.InserirFilme (Filme.GetFilme(8));
            
            cliente = new Cliente (
                "Stefany Joana Pereira",
                new DateTime (1995, 12, 8),
                "564.059.971-54",
                20
            );
            locacao = new Locacao (
                cliente,
                DateTime.Now.AddDays (-2)
            );
            locacao.InserirFilme (Filme.GetFilme(2));
            
            cliente = new Cliente (
                "Amanda Carolina Giovana Araújo",
                new DateTime (1999, 08, 19),
                "628.602.153-10",
                5
            );
            locacao = new Locacao (
                cliente,
                DateTime.Now.AddDays (-10)
            );
            locacao.InserirFilme (Filme.GetFilme(4));
            locacao.InserirFilme (Filme.GetFilme(9));

            locacao = new Locacao (
                cliente,
                DateTime.Now
            );
            locacao.InserirFilme (Filme.GetFilme(1));
            
            cliente = new Cliente (
                "Gabriel Juan Farias",
                new DateTime (1958, 05, 3),
                "647.340.889-42",
                10
            );
            locacao = new Locacao (
                cliente,
                DateTime.Now
            );
            locacao.InserirFilme (Filme.GetFilme(6));
            locacao.InserirFilme (Filme.GetFilme(7));
            locacao.InserirFilme (Filme.GetFilme(8));
        }

    }
}