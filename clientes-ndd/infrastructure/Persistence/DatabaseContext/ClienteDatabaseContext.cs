using System;
using System.Threading;
using System.Threading.Tasks;
using domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Persistence.DatabaseContext
{
    public class ClienteDatabaseContext: DbContext
    {
        public ClienteDatabaseContext(DbContextOptions<ClienteDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
