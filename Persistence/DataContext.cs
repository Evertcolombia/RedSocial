using System;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class DataContext : DbContext
    {
        // create a constructor
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set;}
    }
}
