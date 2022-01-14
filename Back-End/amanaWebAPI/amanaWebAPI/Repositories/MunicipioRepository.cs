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
            List<Municipio> municipios = ctx.Municipios
                .Select(m => new Municipio()
                {
                    IdMunicipio = m.IdMunicipio,
                    IdUf = m.IdUf,
                    NomeMunicipio = m.NomeMunicipio,
                    IdUfNavigation = new Uf()
                    {
                        NomeUf = m.IdUfNavigation.NomeUf,
                        Abreviacao = m.IdUfNavigation.Abreviacao
                    }
                })
                .Where(m => m.IdUf == idUf).ToList();

            return municipios;

        }

        public Municipio BuscarPorId(int idMunicipio)
        {
            return ctx.Municipios
                .Select(m => new Municipio()
                {
                    IdMunicipio = m.IdMunicipio,
                    IdUf = m.IdUf,
                    NomeMunicipio = m.NomeMunicipio,
                    IdUfNavigation = new Uf()
                    {
                        NomeUf = m.IdUfNavigation.NomeUf,
                        Abreviacao = m.IdUfNavigation.Abreviacao
                    }
                })
                .FirstOrDefault(m => m.IdMunicipio == idMunicipio);
        }

        public List<Municipio> ListarTodos()
        {
            return ctx.Municipios
                .Select(m => new Municipio()
                {
                    IdMunicipio = m.IdMunicipio,
                    IdUf = m.IdUf,
                    NomeMunicipio = m.NomeMunicipio,
                    IdUfNavigation = new Uf()
                    {
                        NomeUf = m.IdUfNavigation.NomeUf,
                        Abreviacao = m.IdUfNavigation.Abreviacao
                    }
                })
                .ToList();
        }
    }
}
