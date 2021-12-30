using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class SeguradoraRepository : ISeguradoraRepository
    {

        CotadorContext ctx = new CotadorContext();
        public List<Seguradora> ListarTodas()
        {
            return ctx.Seguradoras.ToList();
        }
    }
}
