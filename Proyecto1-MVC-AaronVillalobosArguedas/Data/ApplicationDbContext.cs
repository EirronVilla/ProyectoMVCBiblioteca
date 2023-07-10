using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto1_MVC_AaronVillalobosArguedas.Models;

namespace Proyecto1_MVC_AaronVillalobosArguedas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Socio> Socios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Libro>()
                .HasMany(e => e.Socios)
                .WithMany(e => e.Libros)
                .UsingEntity<LibroSocio>(
                    s => s.HasOne<Socio>().WithMany().HasForeignKey(e => e.SocioId),
                    l => l.HasOne<Libro>().WithMany().HasForeignKey(e => e.LibroISBN));
        }

        public DbSet<Proyecto1_MVC_AaronVillalobosArguedas.Models.LibroSocio>? LibroSocio { get; set; }
    }
}