using System;
using System.Collections.Generic;
using Models;

namespace Repositories {
    public static class RepositoryLocacao {
        private static readonly List<Locacao> locacoes = new List<Locacao>();

        public static List<Locacao> Locacoes(){
            return locacoes;
        }

        public static void AddLocacao(Locacao Locacao){
            locacoes.Add(Locacao);
        }

        public static int GetId(){
            return locacoes.Count + 1;
        }
    }
}