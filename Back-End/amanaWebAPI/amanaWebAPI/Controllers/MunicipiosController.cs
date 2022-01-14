using amanaWebAPI.Domains;
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
    public class MunicipiosController : ControllerBase
    {
        private IMunicipioRepository _municipioRepository { get; set; }

        public MunicipiosController()
        {
            _municipioRepository = new MunicipioRepository();
        }

        /// <summary>
        /// Lista todos os municipios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_municipioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca todos os municipios de um determinado UF
        /// </summary>
        /// <param name="idUf">Id do UF dos municipios a serem buscados</param>
        /// <returns></returns>
        [HttpGet("uf/{idUf}")]
        public IActionResult GetByIdUf(int idUf)
        {
            try
            {
                return Ok(_municipioRepository.BuscarPeloUf(idUf));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);            }
        }

        /// <summary>
        /// Busca um municipio atraves do seu id
        /// </summary>
        /// <param name="idMunicipio">Id do municipio a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{idMunicipio}")]
        public IActionResult GetById(int idMunicipio)
        {
            try
            {
                Municipio municipioBuscado = _municipioRepository.BuscarPorId(idMunicipio);

                if (municipioBuscado == null) 
                    return NotFound(
                                    new {
                                        mensagem = "Municipío não encontrado",
                                        erro = true
                                    });

                return Ok(municipioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
