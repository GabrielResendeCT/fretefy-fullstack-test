using Fretefy.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fretefy.Test.Domain.Interfaces.Repositories
{
    public interface IRegiaoRepository
    {
        Task<Regiao> GetByIdAsync(Guid id);
        Task<IEnumerable<Regiao>> ListAsync();
        Task<Regiao> CreateAsync(Regiao regiao);
        Task UpdateAsync(Regiao regiao);
        Task AddCidadeToRegiaoAsync(Guid regiaoId, RegiaoCidade cidade);
        Task RemoveCidadeFromRegiaoAsync(Guid regiaoId, Guid cidadeId);
    }
}
