using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RoyalDomain.Interfaces.Common
{
    public interface IRoyalUnitOfWork
    {
        public IDeviceGroupsRepository DeviceGroupsRepository { get; }
        public IRoyalDevicesRepository RoyalDevicesRepository { get; }

        public IDeviceGroupMembershipRepository DeviceGroupMembershipRepository { get; }

        DatabaseFacade GetDatabaseFacade();

        bool SaveChanges();
        Task SaveChangesAsync();
    }
}