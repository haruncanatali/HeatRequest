using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HeatRequest.API.Model
{
    public class HeatRequestAppDbContext:DbContext
    {
        private readonly string connectionString = "Server=DESKTOP-1E3KO5B\\SQLEXPRESS;Database=HeatRequestAppDbo;Trusted_Connection=True;MultipleActiveResultSets=true";
        public HeatRequestAppDbContext(DbContextOptions<HeatRequestAppDbContext> options):base(options)
        {
                
        }

        public DbSet<Heat> Heat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HeatMap());
        }
    }
}
