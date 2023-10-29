using RoyalDomain.Entities;
using RoyalDomain.Interfaces;
using RoyalPersistence.Common;
using RoyalPersistence.Context;

namespace RoyalPersistence.Repositories
{
    public class DeviceGroupMembershipRepository : RoyalBaseRepository<DeviceGroupMemberships>, IDeviceGroupMembershipRepository
    {
        public DeviceGroupMembershipRepository(RoyalDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}