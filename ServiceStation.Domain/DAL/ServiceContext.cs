using ServiceStation.Domain.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ServiceStation.Domain.DAL
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() : base("name=ServiceDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<ClientCard> ClientCardsi { get; set; }
        public DbSet<Orders> Ordersi { get; set; }
        public DbSet<RelatedCars> RelatedCarsi { get; set; }

    }
}
