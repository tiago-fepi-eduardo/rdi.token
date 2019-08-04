using Microsoft.EntityFrameworkCore;
using Token.Domain.Entity;
using Token.Infra.Data.Mappings;

namespace Token.Infra.Data
{
    public class TokenContext : DbContext
    {
        public TokenContext(DbContextOptions options) : base(options)
        {
            //Nothing
        }

        public DbSet<TokenEntity> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TokenEntity>(new TokenMap().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}
