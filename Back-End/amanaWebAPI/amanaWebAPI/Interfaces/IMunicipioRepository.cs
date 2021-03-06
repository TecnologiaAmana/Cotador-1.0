using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface IMunicipioRepository
    {
        /// <summary>
        /// Lista todos os municipios cadastrados
        /// </summary>
        /// <returns></returns>
        List<Municipio> ListarTodos();

        /// <summary>
        /// Busca municipios através de seu Uf
        /// </summary>
        /// <param name="idUf">Uf dos municipios que serão buscados</param>
        /// <returns></returns>
        List<Municipio> BuscarPeloUf(int idUf);

        /// <summary>
        /// Busca um municipio através de seu id
        /// </summary>
        /// <param name="idMunicipio">Id do municipio a ser buscado</param>
        /// <returns></returns>
        Municipio BuscarPorId(int idMunicipio);
    }
}
