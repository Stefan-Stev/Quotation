using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace QuotationsWebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class BaseApiController:ControllerBase
    {
        protected readonly IMapper _mapper;
        public BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
