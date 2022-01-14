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

        public List<int> BuscarComCulturaMunicipio(int idCultura, int idMunicipio)
        {
            
            List<Plantio> plantios = ctx.Plantios.Where(p => p.IdCultura == idCultura && p.IdMunicipio == idMunicipio).ToList();

            List<int> ids = new List<int>();

            foreach (var item in plantios)
            {
                ids.Add(item.IdPlantio);
            }
            return ids;
        }

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
