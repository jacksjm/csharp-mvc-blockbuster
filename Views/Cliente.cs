using System;
using Models;
using Controllers;

namespace View {
    public class ClienteView {
        /// <summary>
        /// This method is responsible for creating customers
        /// </summary>
        public static void InserirCliente () {
            Console.WriteLine ("Informações sobre o cliente: ");
            Console.WriteLine ("Informe o nome: ");
            String nome = Console.ReadLine ();
            Console.WriteLine ("Informe a data de nascimento (dd/mm/yyyy): ");
            String sDtNasc = Console.ReadLine ();
            Console.WriteLine ("Informe o C.P.F.: ");
            String cpf = Console.ReadLine ();
            Console.WriteLine ("Informe a quantidade de dias para devolução: ");
            int qtdDias = Convert.ToInt32 (Console.ReadLine ());

            ClienteController.InserirCliente(nome, sDtNasc, cpf, qtdDias);
        }

        /// <summary>
        /// This method is responsible for listing customers
        /// </summary>
        public static void ListarClientes () {
            Console.WriteLine ("Lista de Clientes: ");
            ClienteController.GetClientes().ForEach (
                cliente => Console.WriteLine (cliente.ToString (true)));
        }

        /// <summary>
        /// This method is responsible for consulting a customer
        /// </summary>
        public static void ConsultarCliente () {
            Cliente cliente;

            // Search the costumer with id
            do {
                Console.WriteLine ("Informe o cliente que deseja consultar: ");
                int idCliente = Convert.ToInt32 (Console.ReadLine ());
                cliente = null; // Reset the value to avoid garbage

                // Try to locate the information in the collection
                try {
                    cliente = ClienteController.GetCliente(idCliente);
                    if (cliente == null) { // If the information is not present, a message is returned
                        Console.WriteLine ("Cliente não localizado, favor digitar outro id.");
                    }
                } catch {
                    Console.WriteLine ("Cliente não localizado, favor digitar outro id.");
                }
            } while (cliente == null);
            Console.WriteLine (cliente.ToString ());
        }

        /// <sumary>This method access db import.</sumary>
        public static void Importar () {
            ClienteController.Importar ();
            Console.WriteLine("======= IMPORTAÇÃO DE CLIENTES E LOCACOES CONCLUÍDA COM SUCESSO =======");
        }
    }
}