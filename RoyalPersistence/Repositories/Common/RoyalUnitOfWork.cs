using Microsoft.EntityFrameworkCore.Infrastructure;
using RoyalDomain.Interfaces;
using RoyalDomain.Interfaces.Common;
using RoyalPersistence.Context;

namespace RoyalPersistence.Repositories.Common
{
    public class RoyalUnitOfWork : IRoyalUnitOfWork
    {
        private RoyalDbContext _applicationDbContext;
        public DatabaseFacade GetDatabaseFacade()
        {
           return _applicationDbContext.GetDatabaseFacade();
        }
        private IDeviceGroupsRepository _deviceGroupsRepository;           
        public IDeviceGroupsRepository DeviceGroupsRepository
        {
            get
            {
                if (_deviceGroupsRepository == null)
                {
                    _deviceGroupsRepository = new DeviceGroupRepository(_applicationDbContext);
                }
                return _deviceGroupsRepository;
            }
        }

        private IRoyalDevicesRepository _royalDevicesRepository;
        public IRoyalDevicesRepository RoyalDevicesRepository
        {
            get
            {
                if (_royalDevicesRepository == null)
                {
                    _royalDevicesRepository = new RoyalDevicesRepository(_applicationDbContext);
                }
                return _royalDevicesRepository;
            }
        }

        private IDeviceGroupMembershipRepository _deviceGroupMembershipRepository;
        public IDeviceGroupMembershipRepository DeviceGroupMembershipRepository
        {
            get
            {
                if (_deviceGroupMembershipRepository == null)
                {
                    _deviceGroupMembershipRepository = new DeviceGroupMembershipRepository(_applicationDbContext);
                }
                return _deviceGroupMembershipRepository;
            }
        }

               

        public RoyalUnitOfWork(RoyalDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
        public bool SaveChanges() => _applicationDbContext.SaveChanges() > 0;
    }    
}
