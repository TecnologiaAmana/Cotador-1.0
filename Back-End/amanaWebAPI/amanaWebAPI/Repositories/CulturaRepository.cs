using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class CulturaRepository : ICulturaRepository
    {
        CotadorContext ctx = new CotadorContext();

        public List<Cultura> ListarTodas()
        {
            return ctx.Culturas.ToList();
        }
    }
}
