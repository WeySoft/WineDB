using System.Collections.Generic;
using WineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WineAPI.Data
{
    public class WineContext : DbContext
    {
        public WineContext(DbContextOptions<WineContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Manufactuer> Manufactuers { get; set; }
        public DbSet<Wine> Wines { get; set; }
    }
}