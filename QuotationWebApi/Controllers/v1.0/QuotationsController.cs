using Application.Commands;
using Application.Contracts.Model;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuotationWebApi.Controllers;
using System;
using System.Threading.Tasks;

namespace QuotationsWebApi.Controllers
{

    [ApiVersion("1.0")]

    public class QuotationsController : BaseApiController
    {
        public QuotationsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediatR.Send(new GetQuotationByIdQuery { Id = id })); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediatR.Send(new GetQuotationsQuery()));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var responseId = await _mediatR.Send(new QuotationDeleteCommand { Id = id });
            var response = new Response { Id = responseId };
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuotationUpdateCommand command)
        {
            if( id != command.Id )
            {
                return BadRequest();
            }
            var responseId = await _mediatR.Send(command);
            var response = new Response { Id = responseId };
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create( QuotationCreateCommand command)
        {
            var responseId = await _mediatR.Send(command);
            var response = new Response { Id = responseId };
            return Ok(response);

        }
        
        [HttpPut("/api/partialUpdate")]
        public async Task<IActionResult> UpdatePartial(QuotationPartialUpdateCommand command)
        {
            var responseId = await _mediatR.Send(command);
            var response = new Response { Id = responseId };
            return Ok(response);
        }

        
    }
}
