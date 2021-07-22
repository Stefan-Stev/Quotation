using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuotationWebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediatR;

        public BaseApiController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
    }
}
