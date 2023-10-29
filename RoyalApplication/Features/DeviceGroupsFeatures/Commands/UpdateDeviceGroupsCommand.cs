using EducationApplication.Interfaces;
using EducationDomain.Entities;
using EducationDomain.Interfaces;
using EducationDomain.ViewModel;
using Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace EducationApplication.Features.CityFeatures.Commands
{
    public class UpdateDeviceGroupsCommand : IRequest<CityUpdateViewModel>
    {
        public short Id { get; set; }
        public short? ProvinceID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public class UpdateCityCommandHandler : IRequestHandler<UpdateDeviceGroupsCommand, CityUpdateViewModel>
        {
            private readonly IEducationUnitOfWork _educationUnitOfWork;
            private readonly ISamaMapping _samaMapping;
            public UpdateCityCommandHandler(IEducationUnitOfWork educationUnitOfWork, ISamaMapping samaMapping)
            {
                _educationUnitOfWork = educationUnitOfWork;
                _samaMapping = samaMapping;
            }
            public async Task<CityUpdateViewModel> Handle(UpdateDeviceGroupsCommand command, CancellationToken cancellationToken)
            {
                var city = await _educationUnitOfWork.CityRepository.FindByCondition(a => a.Id == command.Id).FirstOrDefaultAsync();

                if (city == null) throw new SamaException("102;Entity Id Not Found.");
                else
                {
                    city = _samaMapping.Map<UpdateDeviceGroupsCommand, City>(command, city);
                    _educationUnitOfWork.CityRepository.Update(city);
                    await _educationUnitOfWork.SaveChangesAsync();                    
                    return _samaMapping.Map<CityUpdateViewModel>(city);
                }
            }
        }
    }
}
