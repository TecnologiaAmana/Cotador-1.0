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

        public Cultura BuscarPorId(int idCultura)
        {
            return ctx.Culturas.Where(c => c.IdCultura == idCultura).FirstOrDefault();
        }

        public List<Cultura> ListarTodas()
        {
            return ctx.Culturas.ToList();
        }
    }
}
