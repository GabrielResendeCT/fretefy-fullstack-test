using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Infra.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Fretefy.Test.Infra.EntityFramework
{
    public class TestDbContext : DbContext
    {
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<RegiaoCidade> RegiaoCidade { get; set; }

        // Este construtor agora receberá as opções de configuração do banco de dados diretamente
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui estou aplicando as configurações específicas de cada entidade
            modelBuilder.ApplyConfiguration(new RegiaoMap());
            modelBuilder.ApplyConfiguration(new RegiaoCidadeMap());
        }
    }
}