using RoyalDomain.Entities;
using RoyalDomain.Interfaces;
using RoyalPersistence.Common;
using RoyalPersistence.Context;

namespace RoyalPersistence.Repositories
{
    public class RoyalDevicesRepository : RoyalBaseRepository<RoyalDevices>, IRoyalDevicesRepository
                                                                                       
    {
        public RoyalDevicesRepository(RoyalDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}