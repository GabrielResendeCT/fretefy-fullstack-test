using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces.Repositories;

namespace Fretefy.Test.Infra.EntityFramework.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        private readonly TestDbContext _dbContext;

        public RegiaoRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Regiao> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regiao
                .Include(r => r.RegiaoCidades)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Regiao>> ListAsync()
        {
            return await _dbContext.Regiao
                .Include(r => r.RegiaoCidades)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Regiao> CreateAsync(Regiao regiao)
        {
            if (_dbContext.Regiao.Any(r => r.Nome == regiao.Nome))
                throw new ArgumentException("Já existe uma região com este nome.");

            _dbContext.Regiao.Add(regiao);
            await _dbContext.SaveChangesAsync();

            return regiao;
        }

        public async Task UpdateAsync(Regiao regiao)
        {
            var existingRegiao = await _dbContext.Regiao
                .Include(r => r.RegiaoCidades)
                .FirstOrDefaultAsync(r => r.Id == regiao.Id);

            if (existingRegiao is null)
                throw new KeyNotFoundException("Região não encontrada.");

            existingRegiao.Nome = regiao.Nome;
            existingRegiao.Ativa = regiao.Ativa;

            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCidadeToRegiaoAsync(Guid regiaoId, RegiaoCidade regiaoCidade)
        {
            _dbContext.RegiaoCidade.Add(regiaoCidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCidadeFromRegiaoAsync(Guid regiaoId, Guid cidadeId)
        {
            var cidade = await _dbContext.RegiaoCidade.FindAsync(cidadeId);

            if (cidade is null || cidade.RegiaoId != regiaoId)
                throw new KeyNotFoundException("Cidade não encontrada na região especificada.");

            _dbContext.RegiaoCidade.Remove(cidade);
            await _dbContext.SaveChangesAsync();
        }
    }
}
