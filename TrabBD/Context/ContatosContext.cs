using Microsoft.EntityFrameworkCore;
using TrabBD.Models;

namespace TrabBD.Context
{
    public class ContatosContext : DbContext
    {
        public ContatosContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contato>()
                .HasMany(c => c.Emails)
                .WithOne(c => c.Contato)
                .HasForeignKey(c => c.IdContato)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Contato>()
                .HasMany(c => c.Telefones)
                .WithOne(c => c.Contato)
                .HasForeignKey(c => c.IdContato)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Email>()
                .HasOne(e => e.Contato)
                .WithMany(e => e.Emails)
                .HasForeignKey(e => e.IdContato)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Telefone>()
                .HasOne(e => e.Contato)
                .WithMany(e => e.Telefones)
                .HasForeignKey(e => e.IdContato)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
