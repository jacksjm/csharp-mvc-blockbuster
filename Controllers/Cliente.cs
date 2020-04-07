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

            Cliente.InserirCliente (
                nome,
                dtNasc,
                cpf,
                qtdDias
            );

        }
        /// <sumary>This method access the find a customer.</sumary>
        public static Cliente GetCliente (int idCliente){
            return Cliente.GetCliente(idCliente);
        }

        /// <sumary>This method access all customers.</sumary>
        public static List<Cliente> GetClientes (){
            return Cliente.GetClientes();
        }
    }
}
