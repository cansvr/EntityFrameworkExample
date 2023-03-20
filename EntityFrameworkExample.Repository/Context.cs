using EntityFrameworkExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Repository
{
    public class Context : DbContext
    {
        public DbSet<Users> Users { get; set; }
    }
}