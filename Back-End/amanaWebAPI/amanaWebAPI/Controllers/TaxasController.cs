using amanaWebAPI.Domains;
using amanaWebAPI.Interfaces;
using amanaWebAPI.Repositories;
using amanaWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amanaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaxasController : ControllerBase
    {
        private ITaxaRepository _taxaRepository { get; set; }

        public TaxasController()
        {
            _taxaRepository = new TaxaRepository();
        }

        /// <summary>
        /// Lista todas as taxas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Taxa> lista = _taxaRepository.ListarTodas();

                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma taxa atraves do seu plantio e area
        /// </summary>
        /// <param name="taxa">Informações de plantio e area para a busca</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetByPlantio(TaxaViewModel taxa)
        {
            try
            {
                return Ok(_taxaRepository.BuscarDados(taxa));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
