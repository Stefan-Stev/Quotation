using Application.Commands;
using Application.Contracts.Model;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace QuotationWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]

    public class DossierController : BaseApiController
    {
        public DossierController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediatR.Send(new GetDossierByIdQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediatR.Send(new GetDossiersQuery()));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            Guid responseId = await _mediatR.Send(new DossierDeleteCommand { Id = id });
            var response = new Response { Id = responseId };
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] DossierUpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var responseId = await _mediatR.Send(command);
            var response = new Response { Id = responseId };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DossierCreateCommand command)
        {
            var responseId = await _mediatR.Send(command);
            var response = new Response { Id = responseId };
            return Ok(response);
        }
        
    }
}
