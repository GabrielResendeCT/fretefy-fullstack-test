using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces.Repositories;
using Fretefy.Test.Domain.Interfaces.Services;

public class RegiaoService : IRegiaoService
{
    private readonly IRegiaoRepository _regiaoRepository;

    public RegiaoService(IRegiaoRepository regiaoRepository)
    {
        _regiaoRepository = regiaoRepository;
    }

    public async Task<Regiao> GetByIdAsync(Guid id)
    {
        return await _regiaoRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Regiao>> ListAsync()
    {
        return await _regiaoRepository.ListAsync();
    }

    public async Task<Regiao> CreateAsync(Regiao regiao)
    {
        return await _regiaoRepository.CreateAsync(regiao);
    }

    public async Task UpdateAsync(Regiao regiao)
    {
        await _regiaoRepository.UpdateAsync(regiao);
    }

    public async Task AddCidadeToRegiaoAsync(Guid regiaoId, RegiaoCidade cidade)
    {
        await _regiaoRepository.AddCidadeToRegiaoAsync(regiaoId, cidade);
    }

    public async Task RemoveCidadeFromRegiaoAsync(Guid regiaoId, Guid cidadeId)
    {
        await _regiaoRepository.RemoveCidadeFromRegiaoAsync(regiaoId, cidadeId);
    }
}
