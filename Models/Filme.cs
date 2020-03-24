using System;
using System.Collections.Generic;
using Repositories;
using System.Linq;

namespace Models {
    public class Filme {
        /* 
            Getters and Setters 
        */
        /// <value>Get and Set the value of FilmeId</value>
        public int FilmeId { get; set; }
        /// <value>Get and Set the value of nomeFilme</value>
        public string NomeFilme { get; set; }
        /// <value>Get and Set the value of dtLancamento</value>
        public DateTime DtLancamento { get; set; }
        /// <value>Get and Set the value of sinopse</value>
        public string Sinopse { get; set; }
        /// <value>Get and Set the value of valor</value>
        public double Valor { get; set; }
        /// <value>Get and Set the value of qtdEstoque</value>
        public int QtdEstoque { get; set; }

        /// <summary>Constructor to Filme object.</summary>
        public static void InserirFilme (string nomeFilme, DateTime dtLancamento, string sinopse, double valor, int qtdEstoque) {
            Filme filme = new Filme {
                NomeFilme = nomeFilme,
                DtLancamento = dtLancamento,
                Sinopse = sinopse,
                Valor = valor,
                QtdEstoque = qtdEstoque
            };

            var db = new Context();
            db.Filmes.Add(filme);
            db.SaveChanges();
        }

        /// <sumary>This method find a movie.</sumary>
        public static Filme GetFilme(int FilmeId){
            var db = new Context();
            return (from filme in db.Filmes
                where filme.FilmeId == FilmeId
                select filme).First();
        }

        /// <sumary>This method return all movies.</sumary>
        public static List<Filme> GetFilmes(){
            var db = new Context();
            return db.Filmes.ToList();
        }

        /// <sumary>This method determines the string convertion.</sumary>
        public string ToString (bool simple = false) {
            if (simple) {
                return $"Id: {FilmeId} - Nome: {NomeFilme}";
            }

            string valor = Valor.ToString("C2");

            return $"Nome: {NomeFilme}\n" +
                $"Valor: {valor}\n";
        }
    }
}
