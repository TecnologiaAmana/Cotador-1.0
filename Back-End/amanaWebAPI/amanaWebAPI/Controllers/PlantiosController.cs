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
    public class PlantiosController : ControllerBase
    {
        private IPlantioRepository _plantioRepository { get; set; }

        public PlantiosController()
        {
            _plantioRepository = new PlantioRepository();
        }


        /// <summary>
        /// Busca um plantio atraves do id da seguradora, municipio e cultura
        /// </summary>
        /// <param name="plantio">Objeto plantio com as informações necessárias para busca</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetByData(PlantioViewModel plantio)
        {
            try
            {
                

                int idSeguradora = plantio.IdSeguradora;
                int idMunicipio = plantio.IdMunicipio;
                int idCultura = plantio.IdCultura;

                if (plantio.IdSeguradora == 0)
                {
                    List<int> plantioBuscados = _plantioRepository.BuscarComCulturaMunicipio(idCultura, idMunicipio);

                    if (plantioBuscados != null)
                    {
                        return Ok(plantioBuscados);
                    }
                    return NotFound(
                            new
                            {
                                mensagem = "Plantios não encontrados",
                                erro = true
                            }
                        );
                }

                Plantio plantioBuscado = _plantioRepository.BuscarComDados(idSeguradora, idMunicipio, idCultura);

                if (plantioBuscado != null)
                {
                    return Ok(plantioBuscado);
                }

                return NotFound(new {
                    mensagem = "Plantio não encontrado",
                    erro = true
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
