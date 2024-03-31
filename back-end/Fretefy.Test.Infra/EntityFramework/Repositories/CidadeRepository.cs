using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Infra.EntityFramework.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly TestDbContext _dbContext;

        public CidadeRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Cidade> List()
        {
            return _dbContext.Cidade.AsQueryable();
        }

        public IEnumerable<Cidade> ListByUf(string uf)
        {
            return _dbContext.Cidade.Where(w => EF.Functions.Like(w.UF, $"%{uf}%"));
        }

        public IEnumerable<Cidade> Query(string terms)
        {

            return _dbContext.Cidade.Where(w => EF.Functions.Like(w.Nome, $"%{terms}%") || EF.Functions.Like(w.UF, $"%{terms}%"));
        }
    }
}
