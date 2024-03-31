using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Fretefy.Test.WebApi.DTOs;

namespace Fretefy.Test.WebApi.AppServices.Interfaces
{
    public interface IRegiaoAppService
    {
        Task<IEnumerable<RegiaoDTO>> GetAllAsync();
        Task<RegiaoDTO> GetByIdAsync(Guid id);
        Task<RegiaoDTO> CreateAsync(RegiaoDTO regiaoDto);
        Task UpdateAsync(RegiaoDTO regiaoDto);

        Task AddCidadeToRegiaoAsync(Guid regiaoId, Guid cidadeId);
        Task RemoveCidadeFromRegiaoAsync(Guid regiaoId, Guid cidadeId);
    }
}
