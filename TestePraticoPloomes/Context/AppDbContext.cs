using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestePraticoPloomes.Models;

namespace TestePraticoPloomes.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Livros> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Livros>().ToTable("Livros");
            builder.Entity<Livros>().HasKey(p => p.Id);
            builder.Entity<Livros>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Livros>().Property(p => p.Titulo).HasMaxLength(255);
            builder.Entity<Livros>().Property(p => p.MinhaResenha).HasMaxLength(2555);
            builder.Entity<Livros>().Property(p => p.Autor).HasMaxLength(255);
            builder.Entity<Livros>().Property(p => p.Editora).HasMaxLength(255);
            builder.Entity<Livros>().Property(p => p.Paginas);
            builder.Entity<Livros>().Property(p => p.Lido);
        }


    }
}
