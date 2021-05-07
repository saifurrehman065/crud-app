using MyCrudAppAspDotNetCore.WebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
       
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        public DbSet<Inventory> Inventories { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Inventory>()
        //        .Property(p => p.Price)
        //        .HasColumnType("decimal(18,4)");
        //    modelBuilder.Entity<Inventory>()
        //        .Property(p => p.Rate)
        //        .HasColumnType("decimal(18,4)");
        //}
    }
}
