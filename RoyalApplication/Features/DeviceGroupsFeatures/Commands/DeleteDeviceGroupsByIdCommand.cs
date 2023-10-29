using EducationApplication.Interfaces;
using EducationDomain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace EducationApplication.Features.CityFeatures.Commands
{
    public class DeleteDeviceGroupsByIdCommand : IRequest<string>
    {
        public int Id { get; set; }
        public class DeleteCityByIdCommandHandler : IRequestHandler<DeleteDeviceGroupsByIdCommand, string>
        {
            private readonly IEducationUnitOfWork _educationUnitOfWork;
            public DeleteCityByIdCommandHandler(IEducationUnitOfWork educationUnitOfWork)
            {
                _educationUnitOfWork = educationUnitOfWork;
            }
            public async Task<string> Handle(DeleteDeviceGroupsByIdCommand command, CancellationToken cancellationToken)
            {
                var cities = await _educationUnitOfWork.CityRepository.FindByCondition(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (cities == null) throw new SamaException("102;Entity Id Not Found.");
                _educationUnitOfWork.CityRepository.Delete(cities);
                await _educationUnitOfWork.SaveChangesAsync();
                return cities.Id.ToString();
            }
        }
    }

}
