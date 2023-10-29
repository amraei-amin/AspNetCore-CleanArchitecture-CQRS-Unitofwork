using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RoyalDomain.Entities;

namespace RoyalPersistence.Context
{
    public class RoyalDbContext : DbContext
    {
        public RoyalDbContext(DbContextOptions<RoyalDbContext> options)
            : base(options)
        {
        }

        public DbSet<DeviceGroups> DeviceGroups { get; set; }
        public DbSet<RoyalDevices> RoyalDevices { get; set; }
        public DbSet<DeviceGroupMemberships> DeviceGroupMemberships { get; set; }


        public DatabaseFacade GetDatabaseFacade()
        {
            return Database;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
