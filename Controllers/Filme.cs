using System;
using Models;
using System.Collections.Generic;

namespace Controllers {
    public class FilmeController {
        /// <sumary>This method insert a movie on the database.</sumary> 
        public static void InserirFilme(
            string nome,
            string sDtLancamento,
            string cpf,
            double valor,
            int estoque
        ){
            DateTime dtLancamento;
            try {
                dtLancamento = Convert.ToDateTime (sDtLancamento);
            } catch {
                Console.WriteLine ("Formato inválido de data, será utilizada a data atual pra cadastro");
                dtLancamento = DateTime.Now;
            }

            new Filme(
                nome,
                dtLancamento,
                cpf,
                valor,
                estoque
            );
        }

        /// <summary>This method get the movie rental quantity.</summary>
        public static int GetQtdLocacoes (Filme filme) {
            return filme.Locacoes.Count;
        }

        /// <sumary>This method access the find movie.</sumary>
        public static Filme GetFilme (int idFilme){
            return Filme.GetFilme(idFilme);
        }

        /// <sumary>This method access all movies.</sumary>
        public static List<Filme> GetFilmes (){
            return Filme.GetFilmes();
        }

        /// <sumary>This method access the db import.</sumary>
        public static void Importar () {
            Filme.Importar();
        }
    }
}