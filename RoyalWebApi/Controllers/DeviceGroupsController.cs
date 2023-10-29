using EducationApplication.Features.CityFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using RoyalDomain.ViewModels;
using SamaWebFramework.BaseControllers;

namespace RoyalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceGroupsController : BaseRoyalApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DeviceGroupViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new GetDeviceGroupsQuery()));
    }
}
