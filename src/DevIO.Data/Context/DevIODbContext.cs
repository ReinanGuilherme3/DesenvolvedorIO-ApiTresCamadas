using DevIO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context;

public class DevIODbContext(DbContextOptions<DevIODbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevIODbContext).Assembly);

        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            property.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }
}
