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
    }
}
