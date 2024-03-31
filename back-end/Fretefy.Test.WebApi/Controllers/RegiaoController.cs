using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Fretefy.Test.WebApi.AppServices.Interfaces;
using Fretefy.Test.WebApi.DTOs;

namespace Fretefy.Test.WebApi.Controllers
{
    [ApiController]
    [Route("api/regioes")]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoAppService _regiaoAppService;

        public RegiaoController(IRegiaoAppService regiaoAppService)
        {
            _regiaoAppService = regiaoAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regioesDto = await _regiaoAppService.GetAllAsync();
            return Ok(regioesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var regiaoDto = await _regiaoAppService.GetByIdAsync(id);
            if (regiaoDto == null)
            {
                return NotFound();
            }
            return Ok(regiaoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegiaoDTO regiaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRegiaoDto = await _regiaoAppService.CreateAsync(regiaoDto);
            return CreatedAtAction(nameof(Get), new { id = createdRegiaoDto.Id }, createdRegiaoDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RegiaoDTO regiaoDto)
        {
            await _regiaoAppService.UpdateAsync(regiaoDto);
            return NoContent();
        }

        [HttpPost("{regiaoId}/cidades/{cidadeId}")]
        public async Task<IActionResult> AddCidadeToRegiao(Guid regiaoId, Guid cidadeId)
        {
            await _regiaoAppService.AddCidadeToRegiaoAsync(regiaoId, cidadeId);
            return Ok();
        }

        [HttpDelete("{regiaoId}/cidades/{cidadeId}")]
        public async Task<IActionResult> RemoveCidadeFromRegiao(Guid regiaoId, Guid cidadeId)
        {
            await _regiaoAppService.RemoveCidadeFromRegiaoAsync(regiaoId, cidadeId);
            return NoContent();
        }
    }
}