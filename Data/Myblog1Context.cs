using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Myblog1.Models;

namespace Myblog1.Data
{
    public class Myblog1Context : DbContext
    {
        public Myblog1Context (DbContextOptions<Myblog1Context> options)
            :base(options)
        { }

        public DbSet<Term> Terms { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Relation> Relations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
