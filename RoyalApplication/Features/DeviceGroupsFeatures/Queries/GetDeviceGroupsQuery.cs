using MediatR;
using Microsoft.EntityFrameworkCore;
using RoyalDomain.Interfaces.Common;
using RoyalDomain.ViewModels;
using RoyalUtility.Interface;

namespace EducationApplication.Features.CityFeatures.Queries
{
    public class GetDeviceGroupsQuery : IRequest<IEnumerable<DeviceGroupViewModel>>
    {
        public class GetAllCityQueryHandler : IRequestHandler<GetDeviceGroupsQuery, IEnumerable<DeviceGroupViewModel>>
        {
            private readonly IRoyalUnitOfWork _unitOfWork;
            private readonly IRoyalMapping _royalMapping;
            public GetAllCityQueryHandler(IRoyalUnitOfWork unitOfWork, IRoyalMapping royalMapping)
            {
                _royalMapping = royalMapping;
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<DeviceGroupViewModel>> Handle(GetDeviceGroupsQuery query, CancellationToken cancellationToken)
            {
                var deviceGroups = _unitOfWork.DeviceGroupsRepository.FindAll();

                var deviceGroupMemberships = _unitOfWork.DeviceGroupMembershipRepository.FindAll();

                var royalDevices = _unitOfWork.RoyalDevicesRepository.FindAll();

                var cityViewModels = _royalMapping.Map<IEnumerable<DeviceGroupViewModel>>(await (
                     from c in deviceGroups
                     join p in deviceGroupMemberships on c.Id equals p.DeviceGroup_Id
                     select new
                     {
                         c.Id,
                         DeviceGroupMemberships = p
                     }).ToListAsync());
                return cityViewModels;
            }
        }
    }
}
