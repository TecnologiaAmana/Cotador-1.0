using amanaWebAPI.Interfaces;
using amanaWebAPI.Repositories;
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
    public class CulturasController : ControllerBase
    {
        private ICulturaRepository _culturaRepository { get; set; }

        public CulturasController()
        {
            _culturaRepository = new CulturaRepository();
        }

        /// <summary>
        /// Lista todas as culturas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_culturaRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma cultura atraves do id
        /// </summary>
        /// <param name="idCultura">Id da cultura a ser buscada</param>
        /// <returns></returns>
        [HttpGet("{idCultura}")]
        public IActionResult GetById(int idCultura)
        {
            try
            {
                return Ok(_culturaRepository.BuscarPorId(idCultura));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
