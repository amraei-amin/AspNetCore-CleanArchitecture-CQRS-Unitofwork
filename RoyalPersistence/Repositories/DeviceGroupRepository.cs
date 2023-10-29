using RoyalDomain.Entities;
using RoyalDomain.Interfaces;
using RoyalPersistence.Common;
using RoyalPersistence.Context;

namespace RoyalPersistence.Repositories
{
    public class DeviceGroupRepository : RoyalBaseRepository<DeviceGroups>, IDeviceGroupsRepository
    {
        public DeviceGroupRepository(RoyalDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}