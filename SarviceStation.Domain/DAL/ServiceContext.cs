using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarviceStation.Domain.DAL
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() : base("ModelDbContext")
        {

        }

        //public DbSet<Name> Name { get; set; }
    }
}
