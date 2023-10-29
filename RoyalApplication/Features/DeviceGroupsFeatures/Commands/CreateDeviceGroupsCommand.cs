using EducationApplication.Interfaces;
using EducationDomain.Entities;
using EducationDomain.Interfaces;
using EducationDomain.ViewModel;
using Mapping;
using MediatR;

namespace EducationApplication.Features.CityFeatures.Commands
{
    public class CreateDeviceGroupsCommand : IRequest<CityCreateViewModel>
    {        
        public short? ProvinceID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public class CreateCityCommandHandler : IRequestHandler<CreateDeviceGroupsCommand, CityCreateViewModel>
        {
  
            private readonly IEducationUnitOfWork _educationUnitOfWork;
            private readonly ISamaMapping _samaMapping;
            public CreateCityCommandHandler(IEducationUnitOfWork educationUnitOfWork, ISamaMapping samaMapping)
            {
                _educationUnitOfWork = educationUnitOfWork;
                _samaMapping = samaMapping;
            }
            public async Task<CityCreateViewModel> Handle(CreateDeviceGroupsCommand command, CancellationToken cancellationToken)
            {
                var city = _samaMapping.Map<City>(command);
                _educationUnitOfWork.CityRepository.Create(city);
                await _educationUnitOfWork.SaveChangesAsync();                          
                return _samaMapping.Map<CityCreateViewModel>(city);
            }
        }
    }
}
