using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface ISeguradoraRepository
    {
        /// <summary>
        /// Lista todas as seguradoras cadastradas
        /// </summary>
        /// <returns></returns>
        List<Seguradora> ListarTodas();
    }
}
