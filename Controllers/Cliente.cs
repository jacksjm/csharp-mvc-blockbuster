using System;
using Models;
using System.Collections.Generic;

namespace Controllers {
    public class ClienteController { 

        /// <sumary>This method insert a costumer on the database.</sumary>
        public static void InserirCliente(
            string nome,
            string sDtNasc,
            string cpf,
            int qtdDias
        ) {
            DateTime dtNasc;
            try {
                dtNasc = Convert.ToDateTime (sDtNasc);
            } catch {
                Console.WriteLine ("Formato inválido de data, será utilizada a data atual pra cadastro");
                dtNasc = DateTime.Now;
            }

            new Cliente (
                nome,
                dtNasc,
                cpf,
                qtdDias
            );

        }

        /// <summary>This method get the movies quantitie.</summary>
        /// <returns>Number of films rented by the customer.</returns>
        public static int GetQtdFilmes (Cliente cliente) {
            int qtdFilmes = 0;

            cliente.Locacoes.ForEach (
                locacao => qtdFilmes += locacao.Filmes.Count
            );

            return qtdFilmes;
        }

        /// <sumary>This method access the find a customer.</sumary>
        public static Cliente GetCliente (int idCliente){
            return Cliente.GetCliente(idCliente);
        }

        /// <sumary>This method access all customers.</sumary>
        public static List<Cliente> GetClientes (){
            return Cliente.GetClientes();
        }

        /// <sumary>This method access the db import.</sumary>
        public static void Importar () {
            Cliente.Importar();
        }
    }
}