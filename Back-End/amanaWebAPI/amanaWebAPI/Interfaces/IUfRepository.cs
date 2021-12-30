using amanaWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface IUfRepository
    {
        /// <summary>
        /// Lista todos o UF's
        /// </summary>
        /// <returns></returns>
        List<Uf> ListarTodos();
    }
}
