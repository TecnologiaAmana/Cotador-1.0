using amanaWebAPI.Domains;
using amanaWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Interfaces
{
    interface ITaxaRepository
    {
        /// <summary>
        /// Lista todas as taxas
        /// </summary>
        /// <returns></returns>
        List<Taxa> ListarTodas();

        /// <summary>
        /// Busca e calcula taxa usando area e plantio
        /// </summary>
        /// <param name="taxa"></param>
        /// <returns></returns>
        List<Taxa> BuscarDados(TaxaViewModel taxa);
    }
}
