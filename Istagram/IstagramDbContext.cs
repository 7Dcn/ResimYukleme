using Istagram.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istagram
{
    public class IstagramDbContext : DbContext
    {
        public IstagramDbContext()
        {
            Database.Connection.ConnectionString = "server=.; database=Istagram; trusted_connection=true";
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
