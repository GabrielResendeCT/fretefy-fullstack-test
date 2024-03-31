using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.WebApi.AppServices.Interfaces;
using Fretefy.Test.WebApi.DTOs;

namespace Fretefy.Test.WebApi.AppServices.Implementations
{
    public class CidadeAppService : ICidadeAppService
    {
        private readonly ICidadeService _cidadeService;

        public CidadeAppService(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public CidadeDTO Get(Guid id)
        {
            var cidade = _cidadeService.GetByIdAsync(id);
            return cidade == null ? null : new CidadeDTO
            {
                Id = cidade.Id,
                Nome = cidade.Nome,
                UF = cidade.UF
            };
        }

        public IEnumerable<CidadeDTO> List()
        {
            return _cidadeService.List().Select(c => new CidadeDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                UF = c.UF
            });
        }

        public IEnumerable<CidadeDTO> ListByUf(string uf)
        {
            return _cidadeService.ListByUf(uf).Select(c => new CidadeDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                UF = c.UF
            });
        }

        public IEnumerable<CidadeDTO> Query(string terms)
        {
            return _cidadeService.Query(terms).Select(c => new CidadeDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                UF = c.UF
            });
        }
    }
}
