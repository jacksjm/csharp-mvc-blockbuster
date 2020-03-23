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
        /// <value>Get and Set the value of idLocacao</value>
        public int IdLocacao { get; set; }
        /// <value>Get and Set the value of cliente</value>
        public Cliente Cliente { get; set; }
        /// <value>Get and Set the value of dtLocacao</value>
        public DateTime DtLocacao { get; set; }
        /// <value>Get and Set the value of idCliente</value>
        public List<Filme> Filmes { get; set; }

        /// <summary>
        /// Constructor to Locacao object.
        /// </summary>
        /// <param name="idLocacao">Unique rental identification</param>
        /// <param name="cliente">Customer object</param>
        /// <param name="dtLocacao">Rental date</param>
        public Locacao (Cliente cliente, DateTime dtLocacao) {
            IdLocacao = RepositoryLocacao.GetId();
            Cliente = cliente;
            DtLocacao = dtLocacao;
            Filmes = new List<Filme> ();
            cliente.InserirLocacao (this);

            RepositoryLocacao.AddLocacao (this);
        }

        /// <summary>
        /// This method insert a movie into a customer rental.
        /// </summary>
        /// <param name="filme">The movie object.</param>
        public void InserirFilme (Filme filme) {
            Filmes.Add (filme);
            filme.SetarLocacao (this);
        }

        /// <sumary>This method determines the string convertion.</sumary>
        public override string ToString () {
            string valor = LocacaoController.GetValorTotal(this).ToString("C2");
            string retorno = $"Cliente: {Cliente.Nome}\n" +
                $"Data da Locacao: {DtLocacao}\n" +
                $"Valor: {valor}\n" +
                $"Data de Devolucao: {LocacaoController.GetDataDevolucao(this)}\n" +
                "   Filmes:\n";

            if (Filmes.Count > 0) {
                Filmes.ForEach (
                    filme => retorno += $"    Id: {filme.IdFilme} - " +
                    $"Nome: {filme.NomeFilme}\n"
                );
            } else {
                retorno += "    Não há filmes";
            }

            return retorno;
        }

        /// <sumary>This method find a customer rental.</sumary>
        public static Locacao GetLocacao(int idLocacao){
            return RepositoryLocacao.Locacoes().Find (locacao => locacao.IdLocacao == idLocacao);
        }

    }
}