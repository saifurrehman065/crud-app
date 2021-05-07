using MyCrudAppAspDotNetCore.WebApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace MyCrudAppAspDotNetCore.WebApi.Infrastructure.Context
{
    public interface IApplicationContext
    {
        DbSet<Inventory> Inventories { get; set; }

        Task<int> SaveChangesAsync();
    }
}