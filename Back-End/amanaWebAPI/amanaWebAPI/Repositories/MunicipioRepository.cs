using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        CotadorContext ctx = new CotadorContext();

        public List<Municipio> BuscarPeloUf(int idUf)
        {
            List<Municipio> municipios = ctx.Municipios.Where(m => m.IdUf == idUf).ToList();

            return municipios;

        }

        public List<Municipio> ListarTodos()
        {
            return ctx.Municipios.ToList();
        }
    }
}
