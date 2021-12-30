using amanaWebAPI.Context;
using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Repositories
{
    public class PlantioRepository : IPlantioRepository
    {
        CotadorContext ctx = new CotadorContext();

        public Plantio BuscarComDados(int idSeguradora, int idMunicipio, int idCultura)
        {
           Plantio plantio = ctx.Plantios.FirstOrDefault(p => p.IdSeguradora == idSeguradora && p.IdMunicipio == idMunicipio && p.IdCultura == idCultura);

            return plantio;
        }

        public Plantio BuscarPorId(int idPlantio)
        {
            throw new NotImplementedException();
        }
    }
}
