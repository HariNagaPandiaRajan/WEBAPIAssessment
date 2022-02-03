using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace assesment1.Controllers.models
{
    public class moviedbcontext:DbContext
    {
        internal IEnumerable<object> userinfo;

        public moviedbcontext(DbContextOptions<moviedbcontext> options) : base(options)
        {
        }
        public DbSet<Userdetails> userdetails { get; set; }
        public DbSet<movies> movie { get; set; }
    }
}
