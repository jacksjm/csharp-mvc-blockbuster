using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Repositories;

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

            FilmeLocacao filmeLocacao = new FilmeLocacao();
            filmeLocacao.FilmeId = filme.FilmeId;
            filmeLocacao.LocacaoId = LocacaoId;
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
            // string valor = LocacaoController.GetValorTotal(this).ToString("C2");
            string retorno = $"Cliente: {cliente.Nome}\n" +
                $"Data da Locacao: {DtLocacao}\n" +
                $"Data de Devolucao: {LocacaoController.GetDataDevolucao(DtLocacao, cliente)}\n" +
                "   Filmes:\n";

            if (Filmes.Count > 0) {
                foreach (FilmeLocacao filme in Filmes) {
                    retorno += $"    Id: {filme.Filme.FilmeId} - Nome: {filme.Filme.NomeFilme}\n";
                }
            } else {
                retorno += "    Não há filmes";
            }

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
