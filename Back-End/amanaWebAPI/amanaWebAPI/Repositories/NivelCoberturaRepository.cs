using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class NivelCoberturaRepository : INivelCoberturaRepository
    {
        CotadorContext ctx = new CotadorContext();
        public List<Nivelcobertura> ListarTodos()
        {
            return ctx.Nivelcoberturas.ToList();
        }
    }
}
