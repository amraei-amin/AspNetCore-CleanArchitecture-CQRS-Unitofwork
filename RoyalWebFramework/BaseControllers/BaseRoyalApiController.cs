using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RoyalUtility.Interface;

namespace SamaWebFramework.BaseControllers
{
    [ApiController]
    [Route("api/educate/[controller]")]
    public abstract class BaseRoyalApiController : ControllerBase
    {
        private IMediator _mediator;
        private IRoyalMapping _royalMapping;
        private IServiceProvider _serviceProvider;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
        protected IRoyalMapping RoyalMapping => _royalMapping ?? HttpContext.RequestServices.GetService<IRoyalMapping>();
        protected IServiceProvider ServiceProvider => _serviceProvider ?? HttpContext.RequestServices.GetService<IServiceProvider>();

        //public async Task<(bool, string)> GetValidateAsync<TModel>(TModel model)
        //{
        //    var _validator = ServiceProvider.GetRequiredService<IValidator<TModel>>();
        //    var validationResult = await _validator.ValidateAsync(model);
        //    (bool, string) response = (false, "");
        //    if (!validationResult.IsValid)
        //    {
        //        response.Item1 = true;
        //        response.Item2 = validationResult.ToString();
        //        return response;
        //    }
        //    return response;
        //}
    }
}