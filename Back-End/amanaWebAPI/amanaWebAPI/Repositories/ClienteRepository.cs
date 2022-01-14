using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        CotadorContext ctx = new CotadorContext();

        public Cliente BuscarPorId(int idCliente)
        {
            return ctx.Clientes.Where(c => c.IdCliente == idCliente).FirstOrDefault();
        }

        public List<Cliente> ListarTodos()
        {
            return ctx.Clientes.ToList();
        }
    }
}
