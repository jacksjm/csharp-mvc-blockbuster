using System;
using View;

namespace csharp_mvc_blockbuster
{
    class Program
    {
        /*
            The Main class
            The entrance of the system
        */
        static void Main () {
            Console.WriteLine ("============ Blockbuster! ============ ");
            int opt;
            do {
                // Show menu options
                Console.WriteLine ("+-------------------------+");
                Console.WriteLine ("| Digite a opção desejada |");
                Console.WriteLine ("| 1 - Cadastrar Cliente   |");
                Console.WriteLine ("| 2 - Cadastrar Filme     |");
                Console.WriteLine ("| 3 - Cadastrar Locação   |");
                Console.WriteLine ("| 4 - Listar Clientes     |");
                Console.WriteLine ("| 5 - Consultar Cliente   |");
                Console.WriteLine ("| 6 - Listar Filmes       |");
                Console.WriteLine ("| 7 - Consultar Filme     |");
                Console.WriteLine ("| 8 - Consultar Locação   |");
                Console.WriteLine ("| 0 - Sair                |");
                Console.WriteLine ("+-------------------------+");

                try {
                    opt = Convert.ToInt32 (Console.ReadLine ());
                } catch {
                    Console.WriteLine ("Opção inválida");
                    opt = 99;
                }

                // Checks the selected option
                switch (opt) {
                    case 1:
                        ClienteView.InserirCliente ();
                        break;
                    case 2:
                        FilmeView.InserirFilme ();
                        break;
                    case 3:
                        LocacaoView.InserirLocacao ();
                        break;
                    case 4:
                        ClienteView.ListarClientes ();
                        break;
                    case 5:
                        ClienteView.ConsultarCliente ();
                        break;
                    case 6:
                        FilmeView.ListarFilmes ();
                        break;
                    case 7:
                        FilmeView.ConsultarFilme ();
                        break;
                    case 8:
                        LocacaoView.ConsultarLocacao ();
                        break;
                }
            } while (opt != 0);

        }
    }
}
