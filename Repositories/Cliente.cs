using System;
using System.Collections.Generic;
using Models;

namespace Repositories {
    public static class RepositoryCliente {
        private static readonly List<Cliente> clientes = new List<Cliente>();

        public static List<Cliente> Clientes(){
            return clientes;
        }

        public static void AddCliente(Cliente cliente){
            clientes.Add(cliente);
        }

        public static int GetId(){
            return clientes.Count + 1;
        }
    }
}