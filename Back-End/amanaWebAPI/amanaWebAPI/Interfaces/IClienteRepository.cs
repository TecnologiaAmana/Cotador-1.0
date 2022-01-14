using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface IClienteRepository
    {
        /// <summary>
        /// Lista todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ListarTodos();

        /// <summary>
        /// Busca um cliente atraves do seu id
        /// </summary>
        /// <param name="idCliente">Id do cliente a ser busacado</param>
        /// <returns></returns>
        public Cliente BuscarPorId(int idCliente);
    }
}
