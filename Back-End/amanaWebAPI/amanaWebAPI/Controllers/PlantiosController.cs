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
    public class PlantiosController : ControllerBase
    {
        private IPlantioRepository _plantioRepository { get; set; }

        public PlantiosController()
        {
            _plantioRepository = new PlantioRepository();
        }

        [HttpPost]
        public IActionResult GetByData(PlantioViewModel plantio)
        {
            try
            {
                int idSeguradora = plantio.IdSeguradora;
                int idMunicipio = plantio.IdMunicipio;
                int idCultura = plantio.IdCultura;


                return Ok(_plantioRepository.BuscarComDados(idSeguradora, idMunicipio, idCultura));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
