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

        /// <summary>
        /// Busca um plantio através do idCultra e idMunicipio, trazendo plantio de todas as seguradoras
        /// </summary>
        /// <param name="idCultura">id da Cultura</param>
        /// <param name="idMunicipio">id do Municipio</param>
        /// <returns></returns>
        List<int> BuscarComCulturaMunicipio(int idCultura, int idMunicipio);
    }
}
