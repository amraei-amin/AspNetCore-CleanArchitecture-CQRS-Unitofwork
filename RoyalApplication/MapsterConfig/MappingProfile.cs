using Microsoft.Extensions.DependencyInjection;

namespace RoyalApplication.MapsterConfig
{
    public static class MappingProfile
    {
        public static void AddMapsterConfigEducation(this IServiceCollection services)
        {          
            

            //TypeAdapterConfig<(Product, LmsCourseInfo), ProductCreateViewModel>.NewConfig()
            //   .Map(dest => dest.LmsCourse.Id, src => src.Item2.Id)
            //   .Map(dest => dest.LmsCourse.ShortName, src => src.Item2.ShortName);

            //TypeAdapterConfig<(UpdateCityCommandBody, short), UpdateCityCommand>.NewConfig()
            //    .Map(dest => dest.Id, src => src.Item2)
            //    .Map(dest => dest.Code, src => src.Item1.Code)
            //    .Map(dest => dest.Name, src => src.Item1.Name)
            //    .Map(dest => dest.ProvinceID, src => src.Item1.ProvinceID);

                          
        }
    }
}