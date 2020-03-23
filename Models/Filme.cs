using System;
using System.Collections.Generic;
using Controllers;
using Repositories;

namespace Models {
    public class Filme {
        /* 
            Getters and Setters 
        */
        /// <value>Get and Set the value of idFilme</value>
        public int IdFilme { get; set; }
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
        /// <value>Get and Set the value of locacoes</value>
        public List<Locacao> Locacoes { get; set; }

        /// <summary>Constructor to Filme object.</summary>
        public Filme (string nomeFilme, DateTime dtLancamento, string sinopse, double valor, int qtdEstoque) {
            IdFilme = RepositoryFilme.GetId();
            NomeFilme = nomeFilme;
            DtLancamento = dtLancamento;
            Sinopse = sinopse;
            Valor = valor;
            QtdEstoque = qtdEstoque;
            Locacoes = new List<Locacao> ();

            RepositoryFilme.AddFilme(this);
        }

        /// <summary>This method insert a movie into a customer rental.</summary>
        /// <param name="filme">The rental object.</param>
        public void SetarLocacao (Locacao locacao) {
            Locacoes.Add (locacao);
        }

        /// <sumary>This method find a movie.</sumary>
        public static Filme GetFilme(int idFilme){
            return RepositoryFilme.Filmes().Find (filme => filme.IdFilme == idFilme);
        }

        /// <sumary>This method return all movies.</sumary>
        public static List<Filme> GetFilmes(){
            return RepositoryFilme.Filmes();
        }

        /// <sumary>This method determines the string convertion.</sumary>
        public string ToString (bool simple = false) {
            if (simple) {
                return $"Id: {IdFilme} - Nome: {NomeFilme}";
            }

            string valor = Valor.ToString("C2");

            return $"Nome: {NomeFilme}\n" +
                $"Valor: {valor}\n" +
                $"Qtd de Locacoes: {FilmeController.GetQtdLocacoes(this)}";
        }

        /// <sumary>This method import movies on the database.</sumary>
        public static void Importar(){
            /* Generate movies*/
            new Filme (
                "Titanic",
                new DateTime (1997, 1, 1),
                "A bordo do luxuoso transatlântico, Rose, uma jovem da alta sociedade, se sente pressionada com a vida que leva. Ao conhecer Jack, um artista pobre e aventureiro, os dois se apaixonam. Mas eles terão que enfrentar um desafio ainda maior que o preconceito social com o destino trágico do navio.",
                10,
                2
            );
            new Filme (
                "Pulp Fiction - Tempo De Violência",
                new DateTime (1994, 1, 1),
                "Os assassinos Vincent e Jules passam por imprevistos ao recuperar uma mala para um mafioso. O boxeador Butch é pago pelo mesmo mafioso para perder uma luta, e a esposa do criminoso fica sob responsabilidade de Vincent por uma noite. Essas histórias se relacionam numa teia repleta de violência.",
                15,
                1
            );
            new Filme (
                "Rocky - Um Lutador",
                new DateTime (1976, 1, 1),
                "Rocky (Sylvester Stallone) é um lutador de boxe desconhecido que é desafiado pelo campeão dos pesos pesados, Apollo Creed (Carl Weathers). Rocky vê a luta como uma oportunidade e começa a treinar intensivamente para ser o vencedor. Vencedor do Oscar de Melhor Filme, Melhor Diretor e Melhor Edição.",
                25,
                1
            );
            new Filme (
                "Vingadores: Guerra Infinita",
                new DateTime (2018, 1, 1),
                "O cruel Thanos pretende reunir todas as Jóias do Infinito em sua manopla para tornar-se o mais poderoso da galáxia e ser capaz de decidir o futuro da humanidade. Os Vingadores então se unem aos Guardiões da Galáxia e ao Pantera Negra na maior guerra de todos os tempos para impedir os planos do vilão.",
                30,
                3
            );
            new Filme (
                "Bohemian Rhapsody",
                new DateTime (2018, 1, 1),
                "Juntos, Freddie Mercury (Rami Malek), Brian May (Gwilym Lee), Roger Taylor (Ben Hardy) e John Deacon (Joe Mazzello) começam a banda Queen, que revoluciona o cenário da música nos anos 70. Mercury é um cantor talentoso e de personalidade singular, mas os excessos começam a representar um problema para o futuro da banda. Baseado em fatos reais, o filme foi vencedor de quatro Oscars.",
                Convert.ToDouble ("25,6"),
                2
            );
            new Filme (
                "Azul É A Cor Mais Quente",
                new DateTime (2013, 1, 1),
                "A estudante Adèle (Adèle Exarchopoulos) vive em uma fase de autoconhecimento. Quando conhece Emma (Léa Seydoux), uma garota lésbica, ela se sente atraída e as duas começam a passar muito tempo juntas. Com isso, as colegas de Adèle a pressionam sobre sua sexualidade ao passo que o laço com Emma fica cada vez mais forte. Vencedor de 3 Palmas de Ouro no Festival de Cannes.",
                10,
                2
            );
            new Filme (
                "La La Land - Cantando Estações",
                new DateTime (2016, 1, 1),
                "Em Los Angeles, a aspirante a atriz Mia (Emma Stone) e o pianista de jazz Sebastian (Ryan Gosling) se apaixonam e juntos passam a perseguir seus sonhos e vontades. Conforme buscam o que desejam, os dois tentam fazer seu relacionamento dar certo. Vencedor de 6 Oscars.",
                Convert.ToDouble ("15,5"),
                1
            );
            new Filme (
                "Central Do Brasil",
                new DateTime (1998, 1, 1),
                "Dora (Fernanda Montenegro) escreve cartas para analfabetos na Central do Brasil. Uma de suas clientes tenta reaproximar o filho Josué (Vinícius de Oliveira) do pai, mas morre ao sair da estação. Dora então ajuda a criança encontrar o pai desaparecido.",
                20,
                1
            );
            new Filme (
                "Clube Dos Cinco",
                new DateTime (1985, 1, 1),
                "Um cdf, um atleta, um caso perdido, uma princesa e um criminoso. Por pequenas infrações, os cinco adolescentes são obrigados a passar o sábado no colégio e escrever uma redação sobre o que pensam sobre si mesmos. Com o tempo eles colocam os rótulos de lado e começam a se abrir uns com os outros.",
                10,
                2
            );
            new Filme (
                "Kill Bill - Volume 1",
                new DateTime (2003, 1, 1),
                "A espadachim conhecida como \"A Noiva\" é uma das assassinas lideradas pelo misterioso Bill. Grávida, ela decide deixar o grupo, mas seus antigos companheiros se viram contra ela e a atacam durante o seu casamento. Após cinco anos em coma, ela parte em busca de vingança.",
                15,
                1
            );
        }
    }
}