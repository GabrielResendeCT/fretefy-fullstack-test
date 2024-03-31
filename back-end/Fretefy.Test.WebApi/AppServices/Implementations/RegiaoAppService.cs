using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Interfaces.Services;
using Fretefy.Test.Domain.Services;
using Fretefy.Test.WebApi.AppServices.Interfaces;
using Fretefy.Test.WebApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fretefy.Test.WebApi.AppServices.Implementations
{
    public class RegiaoAppService : IRegiaoAppService
    {
        private readonly IRegiaoService _regiaoService;
        private readonly ICidadeService _cidadeService;

        public RegiaoAppService(IRegiaoService regiaoService, 
                                ICidadeService cidadeService)
        {
            _regiaoService = regiaoService;
            _cidadeService = cidadeService;
        }

        public async Task<IEnumerable<RegiaoDTO>> GetAllAsync()
        {
            var regioes = await _regiaoService.ListAsync();
            return regioes.Select(regiao => new RegiaoDTO
            {
                Id = regiao.Id,
                Nome = regiao.Nome,
                Ativa = regiao.Ativa,
                Cidades = regiao.RegiaoCidades.Select(regiaoCidade => new CidadeDTO
                {
                    Id = regiaoCidade.CidadeId,
                    Nome = regiaoCidade.Cidade.Nome,
                    UF = regiaoCidade.Cidade.UF
                }).ToList()
            });
        }

        public async Task<RegiaoDTO> GetByIdAsync(Guid id)
        {
            var regiao = await _regiaoService.GetByIdAsync(id);
            if (regiao == null) return null;

            return new RegiaoDTO
            {
                Id = regiao.Id,
                Nome = regiao.Nome,
                Ativa = regiao.Ativa,
                Cidades = regiao.RegiaoCidades.Select(regiaoCidade => new CidadeDTO
                {
                    Id = regiaoCidade.CidadeId,
                    Nome = regiaoCidade.Cidade.Nome,
                    UF = regiaoCidade.Cidade.UF
                }).ToList()
            };
        }

        public async Task<RegiaoDTO> CreateAsync(RegiaoDTO regiaoDto)
        {
            var regiao = new Regiao
            {
                Nome = regiaoDto.Nome,
                Ativa = regiaoDto.Ativa,
                RegiaoCidades = regiaoDto.Cidades.Select(cidadeDto => new RegiaoCidade
                {
                    CidadeId = cidadeDto.Id,
                    RegiaoId = regiaoDto.Id
                }).ToList()
            };

            var createdRegiao = await _regiaoService.CreateAsync(regiao);
            regiaoDto.Id = createdRegiao.Id;
            return regiaoDto;
        }

        public async Task UpdateAsync(RegiaoDTO regiaoDto)
        {
            var regiao = new Regiao
            {
                Id = regiaoDto.Id,
                Nome = regiaoDto.Nome,
                Ativa = regiaoDto.Ativa
            };

            await _regiaoService.UpdateAsync(regiao);
        }

        public async Task AddCidadeToRegiaoAsync(Guid regiaoId, Guid cidadeId)
        {
            var regiao = await _regiaoService.GetByIdAsync(regiaoId);

            if (regiao is null)
                throw new KeyNotFoundException("Região não encontrada.");

            var cidade = _cidadeService.GetByIdAsync(cidadeId);

            if (cidade is null)
                throw new KeyNotFoundException("Cidade não encontrada.");

            var regiaoCidade = new RegiaoCidade
            {
                RegiaoId = regiaoId,
                CidadeId = cidadeId
            };

            await _regiaoService.AddCidadeToRegiaoAsync(regiaoId, regiaoCidade);
        }

        public async Task RemoveCidadeFromRegiaoAsync(Guid regiaoId, Guid cidadeId)
        {
            await _regiaoService.RemoveCidadeFromRegiaoAsync(regiaoId, cidadeId);
        }
    }
}
