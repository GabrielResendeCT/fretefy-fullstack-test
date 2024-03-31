using System;
using System.Collections.Generic;
using Fretefy.Test.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Fretefy.Test.WebApi.AppServices.Interfaces;

namespace Fretefy.Test.WebApi.Controllers
{
    [ApiController]
    [Route("api/cidades")] // Ajuste realizado, plural pode ser uma boa prática REST
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeAppService _cidadeAppService;

        public CidadeController(ICidadeAppService cidadeAppService)
        {
            _cidadeAppService = cidadeAppService;
        }

        [HttpGet]
        public IActionResult List([FromQuery] string uf, [FromQuery] string terms)
        {
            IEnumerable<CidadeDTO> cidadesDto;

            if (!string.IsNullOrEmpty(terms))
                cidadesDto = _cidadeAppService.Query(terms);
            else if (!string.IsNullOrEmpty(uf))
                cidadesDto = _cidadeAppService.ListByUf(uf);
            else
                cidadesDto = _cidadeAppService.List();

            return Ok(cidadesDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var cidadeDto = _cidadeAppService.Get(id);

            if (cidadeDto is null)
                return NotFound();
            else
                return Ok(cidadeDto);
        }
    }
}
