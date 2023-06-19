using Microsoft.EntityFrameworkCore;
using Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations.DatabaseContext
{
    public class DbContextClass: DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions):base(contextOptions)
        {
            
        }
        public DbSet<Client> Client { get; set; }
    }
}
