using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface ICulturaRepository
    {
        /// <summary>
        /// Lista todas as culturas cadastradas
        /// </summary>
        /// <returns></returns>
        List<Cultura> ListarTodas();

        /// <summary>
        /// Busca uma cultura atraves de seu id
        /// </summary>
        /// <param name="idCultura">Id da cultura a ser buscada</param>
        /// <returns></returns>
        Cultura BuscarPorId(int idCultura);
    }
}
