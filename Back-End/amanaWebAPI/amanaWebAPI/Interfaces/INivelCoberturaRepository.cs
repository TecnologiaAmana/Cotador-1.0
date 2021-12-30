using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface INivelCoberturaRepository
    {
        /// <summary>
        /// Lista todos os niveis de cobertura cadastrados
        /// </summary>
        /// <returns></returns>
        List<Nivelcobertura> ListarTodos();
    }
}
