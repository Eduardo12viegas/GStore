using GStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GStore.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias {get; set; }
    public DbSet<Produto> Produtos {get; set; }
    public DbSet<ProdutoFoto> ProdutoFotos {get; set; }
    public DbSet<Usuario> Usuario {get; set; }
}
