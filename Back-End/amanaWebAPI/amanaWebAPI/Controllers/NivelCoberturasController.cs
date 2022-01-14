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
    public class NivelCoberturasController : ControllerBase
    {
        private INivelCoberturaRepository _nivelCoberturaRepository { get; set; }

        public NivelCoberturasController()
        {
            _nivelCoberturaRepository = new NivelCoberturaRepository();
        }
        
        /// <summary>
        /// Lista todos os niveis de cobertura cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_nivelCoberturaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
