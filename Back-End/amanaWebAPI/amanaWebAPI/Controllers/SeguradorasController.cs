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
    public class SeguradorasController : ControllerBase
    {
        private ISeguradoraRepository _seguradoraRepository { get; set; }

        public SeguradorasController()
        {
            _seguradoraRepository = new SeguradoraRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_seguradoraRepository.ListarTodas());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
