using EducationApplication.Interfaces;
using EducationDomain.Interfaces;
using EducationDomain.ViewModel;
using Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace EducationApplication.Features.CityFeatures.Queries
{
    public class GetDeviceGroupsByIdQuery : IRequest<CityByIdViewModel>
    {
        public short Id { get; set; }
        public class GetCityByIdQueryHandler : IRequestHandler<GetDeviceGroupsByIdQuery, CityByIdViewModel>
        {
            private readonly IEducationUnitOfWork _educationUnitOfWork;
            private readonly ISamaMapping _samaMapping;
            public GetCityByIdQueryHandler(IEducationUnitOfWork educationUnitOfWork, ISamaMapping samaMapping)
            {
                _educationUnitOfWork = educationUnitOfWork;
                _samaMapping = samaMapping;
            }
            public async Task<CityByIdViewModel> Handle(GetDeviceGroupsByIdQuery query, CancellationToken cancellationToken)
            {
                var cities = await _educationUnitOfWork.CityRepository.FindByCondition(x => x.Id == query.Id).FirstOrDefaultAsync();
                if (cities == null) throw new SamaException("102;Entity Id Not Found.");

                var provinces = await _educationUnitOfWork.ProvinceRepository.FindAll().FirstOrDefaultAsync(a => a.Id == cities.ProvinceID);

                var cityByIdViewModel = _samaMapping.Map<CityByIdViewModel>(cities);
                cityByIdViewModel.Province = _samaMapping.Map<ProvinceCityByIdViewModel>(provinces);

                return cityByIdViewModel;
            }
        }
    }
}
