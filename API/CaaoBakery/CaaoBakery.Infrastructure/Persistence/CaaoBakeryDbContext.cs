using CaaoBakery.Domain.ProductAggregate;
using CaaoBakery.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CaaoBakery.Infrastructure.Persistence
{

    public class CaaoBakeryDbContext : DbContext
    {
        public CaaoBakeryDbContext(DbContextOptions<CaaoBakeryDbContext> options)
        : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator is not null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CaaoBakeryDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
