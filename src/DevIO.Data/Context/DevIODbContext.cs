using DevIO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context;

public class DevIODbContext(DbContextOptions<DevIODbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
}
