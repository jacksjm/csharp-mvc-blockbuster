using System;
using System.Collections.Generic;
using Models;

namespace Repositories {
    public static class RepositoryFilme {
        private static readonly List<Filme> filmes = new List<Filme>();

        public static List<Filme> Filmes(){
            return filmes;
        }

        public static void AddFilme(Filme Filme){
            filmes.Add(Filme);
        }

        public static int GetId(){
            return filmes.Count + 1;
        }
    }
}