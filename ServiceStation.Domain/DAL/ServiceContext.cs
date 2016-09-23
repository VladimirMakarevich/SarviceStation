using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.DAL
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() : base("name=ServiceDbContext")
        {

        }

        public DbSet<ClientCard> ClientCardsi { get; set; }
        public DbSet<Orders> Ordersi { get; set; }
        public DbSet<RelatedCars> RelatedCarsi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
