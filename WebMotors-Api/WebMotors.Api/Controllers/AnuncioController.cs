using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Application.Contract;
using WebMotors.Application.Dto;

namespace WebMotors.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }


        [HttpGet("BuscaAnuncio")]
        public async Task<IActionResult> GetAnuncio(string tema)
        {
            try
            {
                var anuncio = await _anuncioService.GetAnuncio(tema);
                if (anuncio == null) return NoContent();

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar anuncio. Erro: {ex.Message}");
            }
        }

        [HttpPost("InsereAnuncio")]
        public async Task<IActionResult> AdicionaCliente(AnuncioDto model)
        {
            try
            {
                var anuncio = await _anuncioService.AddAnuncio(model);
                if (anuncio == null) return NoContent();

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o anuncio. Erro: {ex.Message}");
            }
        }

        [HttpPut("AtualizaAnuncio")]
        public async Task<IActionResult> AtualizaAnuncio(int id, AnuncioDto model)
        {
            try
            {
                var anuncio = await _anuncioService.UpdateAnuncio(id, model);
                if (anuncio == false) return NoContent();

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o anuncio. Erro: {ex.Message}");
            }
        }

        [HttpDelete("DeletaAnuncio/{IdAnuncio}")]
        public async Task<IActionResult> DeletaAnuncio(int id)
        {
            try
            {
                var anuncio = await _anuncioService.DeleteAnuncio(id);
                if (anuncio == null) return NoContent();

                return Ok(anuncio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar anuncio. Erro: {ex.Message}");
            }
        }
    }
}
