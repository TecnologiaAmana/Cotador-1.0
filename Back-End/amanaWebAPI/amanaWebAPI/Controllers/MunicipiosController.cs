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

        [HttpGet("{idUf}")]
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
    }
}
