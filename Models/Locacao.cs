using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Repositories;
using System.ComponentModel.DataAnnotations;

namespace Models {
    public class Locacao {
        /* 
            Getters and Setters 
        */
        /// <value>Get and Set the value of LocacaoId</value>
        public int LocacaoId { get; set; }
        /// <value>Get and Set the value of cliente</value>
        public int ClienteId { get; set; }
        /// <value>Get and Set the value of cliente</value>
        public virtual Cliente Cliente { get; set; }
        /// <value>Get and Set the value of dtLocacao</value>
        [Required]
        public DateTime DtLocacao { get; set; }
        /// <value>Get and Set the value of Filmes</value>
        public ICollection<FilmeLocacao> Filmes { get; set; }

        public Locacao(){
            Filmes = new List<FilmeLocacao>();
        }

        /// <summary>
        /// Constructor to Locacao object.
        /// </summary>
        /// <param name="LocacaoId">Unique rental identification</param>
        /// <param name="cliente">Customer object</param>
        /// /// <param name="dtLocacao">Rental date</param>
        public static Locacao InserirLocacao (Cliente cliente, DateTime dtLocacao) {
            Locacao locacao = new Locacao {
                ClienteId = cliente.ClienteId,
                DtLocacao = dtLocacao,
                Filmes = new List<FilmeLocacao> ()
            };

            cliente.InserirLocacao (locacao);

            var db = new Context();
            db.Locacoes.Add(locacao);
            db.SaveChanges();

            return locacao;
        }

        /// <summary>
        /// This method insert a movie into a customer rental.
        /// </summary>
        /// <param name="filme">The movie object.</param>
        public void InserirFilme (Filme filme) {
            var db = new Context();

            FilmeLocacao filmeLocacao = new FilmeLocacao(){
                FilmeId = filme.FilmeId,
                LocacaoId = LocacaoId
            };

            db.FilmeLocacao.Add(filmeLocacao);
            db.SaveChanges();
            Filmes.Add (filmeLocacao);
            filme.Locacoes.Add(filmeLocacao);
            
        }

        /// <sumary>This method determines the string convertion.</sumary>
        public override string ToString () {
            var db = new Context();
            Cliente cliente = (
                    from cli in db.Clientes
                    where cli.ClienteId == ClienteId
                    select cli).First();
            string retorno = $"Cliente: {cliente.Nome}\n" +
                $"Data da Locacao: {DtLocacao}\n" +
                $"Data de Devolucao: {LocacaoController.GetDataDevolucao(DtLocacao, cliente)}\n";

            double valorTotal = 0;
            string strFilmes = "";

            IEnumerable<int> filmes = 
                from filme in db.FilmeLocacao
                    where filme.LocacaoId == LocacaoId
                    select filme.FilmeId;
            if (filmes.Count() > 0) {
                foreach (int id in filmes) {
                    Filme filme = Filme.GetFilme(id);
                    strFilmes += $"    Id: {filme.FilmeId} - Nome: {filme.NomeFilme}\n";
                    valorTotal += filme.Valor;
                }
            } else {
                strFilmes += "    Não há filmes";
            }

            retorno += $"Valor Total: {valorTotal:C2}\n" +
                "   Filmes:\n" +
                strFilmes;

            return retorno;
        }

        /// <sumary>This method find a customer rental.</sumary>
        public static Locacao GetLocacao(int LocacaoId){
            var db = new Context();
            return (from locacao in db.Locacoes
                where locacao.LocacaoId == LocacaoId
                select locacao).First();
        }

    }
}
