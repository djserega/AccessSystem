using AccessSystem.Models.Object;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSystem.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<Base> Base { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<User> User { get; set; }
    }
}
