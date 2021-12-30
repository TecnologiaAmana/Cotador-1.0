using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class UfRepository : IUfRepository
    {
        CotadorContext ctx = new CotadorContext();
        public List<Uf> ListarTodos()
        {
            return ctx.Ufs.ToList();
        }
    }
}
