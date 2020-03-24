using System;
using Models;

namespace Controllers {
    public class LocacaoController {

        /// <sumary>This method insert a customer rental on the database.</sumary> 
        public static Locacao InserirLocacao(
            Cliente cliente
        ){
            return Locacao.InserirLocacao(cliente, DateTime.Now); 
        }

        /// <sumary>This method insert a movie on the customer rental.</sumary>
        public static void InserirFilme(
            Locacao locacao,
            Filme filme
        ){
            locacao.InserirFilme(filme);
        }

        /// <summary>
        /// This method get the total value of the rental
        /// </summary>
        /// <returns>The value of the rental.</returns>
        public static double GetValorTotal (Locacao locacao) {
            double valorTotal = 0;

            locacao.Filmes.ForEach (
                filme => valorTotal += filme.Valor
            );
            return valorTotal;
        }

        /// <summary>
        /// This method get the number of films
        /// </summary>
        /// <returns>The number of films</returns>
        public static double GetQtdFilmes (Locacao locacao) {
            return locacao.Filmes.Count;
        }

        /// <summary>
        /// This method calculates the return date
        /// </summary>
        /// <returns>The customer's return date</returns>
        public static DateTime GetDataDevolucao (DateTime DtLocacao, Cliente Cliente) {
            return DtLocacao.AddDays (Cliente.Dias);
        }

        /// <sumary>This method access find a customer rental.</sumary>
        public static Locacao GetLocacao (int idLocacao){
            return Locacao.GetLocacao(idLocacao);
        }
    }
}
