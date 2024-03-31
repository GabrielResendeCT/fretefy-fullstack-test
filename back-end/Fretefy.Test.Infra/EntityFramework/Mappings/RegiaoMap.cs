using Fretefy.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RegiaoMap : IEntityTypeConfiguration<Regiao>
{
    public void Configure(EntityTypeBuilder<Regiao> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Nome)
            .IsRequired()
            .HasMaxLength(200); // O nome não deverá ter mais de 200 caracteres.

        builder.Property(r => r.Ativa)
            .IsRequired();

        builder.HasMany(r => r.RegiaoCidades)
               .WithOne(c => c.Regiao)
               .HasForeignKey(c => c.RegiaoId)
               .OnDelete(DeleteBehavior.Cascade); // Define a exclusão em cascata.

        builder.HasIndex(r => r.Nome).IsUnique(); // Para garantir que o nome da região seja único.
    }
}