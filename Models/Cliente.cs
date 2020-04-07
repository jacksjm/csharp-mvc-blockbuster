using System;
using System.Collections.Generic;
using Repositories;
using Controllers;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Models {
    public class Cliente {
        /* 
            Getters and Setters 
        */
        /// <value>Get and Set the value of ClienteId</value>
        [Key]
        public int ClienteId { get; set; }
        /// <value>Get and Set the value of nome</value>
        [Required]
        public string Nome { get; set; }
        /// <value>Get and Set the value of dtNasc</value>
        public DateTime DtNasc { get; set; }
        /// <value>Get and Set the value of cpf</value>
        public string Cpf { get; set; }
        /// <value>Get and Set the value of dias</value>
        public int Dias { get; set; }
        /// <value>Get and Set the value of locacoes</value>
        public ICollection<Locacao> Locacoes { get; set; }

        public Cliente(){
            Locacoes = new List<Locacao>();
        }

        /// <summary>Constructor to Cliente object.</summary>
        public static void InserirCliente (string nome, DateTime dtNasc, string cpf, int dias) {
            Cliente cliente = new Cliente {
                Nome = nome,
                DtNasc = dtNasc,
                Cpf = cpf,
                Dias = dias,
                Locacoes = new List<Locacao> ()
            };

            var db = new Context();
            db.Clientes.Add(cliente);
            db.SaveChanges();
        }
        
        /// <summary>This method insert a new movie rental for the customer.</summary>
        /// <param name="locacao">The rental object.</param>
        public void InserirLocacao (Locacao locacao) {
            Locacoes.Add (locacao);
        }

        /// <sumary>This method find a customer.</sumary>
        public static Cliente GetCliente(int ClienteId){
            var db = new Context();
            return (from cliente in db.Clientes
                where cliente.ClienteId == ClienteId
                select cliente).First();
        }

        /// <sumary>This method find return all customers.</sumary>
        public static List<Cliente> GetClientes(){
            var db = new Context();
            return db.Clientes.ToList();
        }

        /// <sumary>This method determines the string convertion.</sumary>
        public string ToString (bool simple = false) {
            Context db = new Context();
            List<Locacao> LocacoesList = (
                    from locacao in db.Locacoes
                    where locacao.ClienteId == ClienteId
                    select locacao).ToList();

            if (simple) {
                string retorno = $"Id: {ClienteId} - Nome: {Nome}\n" +
                    "   Locações: \n";
                if (LocacoesList.Count > 0) {
                    LocacoesList.ForEach (
                        locacao => retorno += $"    Id: {locacao.LocacaoId} - " +
                        $"Data: {locacao.DtLocacao} - " +
                        $"Data de Devolução: {LocacaoController.GetDataDevolucao(locacao.DtLocacao, this)}\n"
                    );
                } else {
                    retorno += "    Não há locações";
                }

                return retorno;
            }

            int qtdFilmes = 0;
            foreach(Locacao locacao in LocacoesList){
                qtdFilmes += (from filme in db.FilmeLocacao
                    where filme.LocacaoId == locacao.LocacaoId
                    select filme).Count();
            }

            string dtNasc = DtNasc.ToString("dd/MM/yyyy");

            return $"Nome: {Nome}\n" +
                $"Data de Nasciment: {dtNasc}\n" +
                $"Qtd de Filmes: {qtdFilmes}";
        }

    }
}
