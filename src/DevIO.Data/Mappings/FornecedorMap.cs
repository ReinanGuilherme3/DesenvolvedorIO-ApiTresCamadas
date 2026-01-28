using DevIO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Mappings;

internal class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("Fornecedores");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(f => f.Documento)
            .IsRequired()
            .HasColumnType("varchar(14)");

        builder.Property(f => f.TipoFornecedor)
            .IsRequired()
            .HasColumnType("int");

        // 1 : 1 => Fornecedor : Endereco
        builder.HasOne(f => f.Endereco)
            .WithOne(e => e.Fornecedor);

        // 1 : N => Fornecedor : Produtos
        builder.HasMany(f => f.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId);
    }
}
