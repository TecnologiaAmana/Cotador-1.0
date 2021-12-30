using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface IPlantioRepository
    {
        /// <summary>
        /// Busca um plantio através de seu id
        /// </summary>
        /// <param name="idPlantio">Id do plantio a ser buscado</param>
        /// <returns></returns>
        Plantio BuscarPorId(int idPlantio);

        /// <summary>
        /// Busca um plantio através de seus dados
        /// </summary>
        /// <param name="idSeguradora"></param>
        /// <param name="idMunicipio"></param>
        /// <param name="idCultura"></param>
        /// <returns></returns>
        Plantio BuscarComDados(int idSeguradora, int idMunicipio, int idCultura);
    }
}
