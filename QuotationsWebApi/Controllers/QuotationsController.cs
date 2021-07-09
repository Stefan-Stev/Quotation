using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotationsWebApi.Dtos;
using QuotationsWebApi.Entities;
using QuotationsWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuotationsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationsController : ControllerBase
    {
        private readonly IQuotationRepository quotationRepository;
        private readonly IMapper _mapper;

        public QuotationsController(IQuotationRepository quotationRepository, IMapper mapper)
        {
            this.quotationRepository = quotationRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult <List<Quotation>>> GetQuotations()
        {
            return Ok(await quotationRepository.GetAllQuotations());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<QuotationDto>> GetQuotationById(Guid id)
        {
            try
            {
                Quotation quotationEntity = await quotationRepository.GetQuotationById(id);
                var quotationDto = _mapper.Map<QuotationDto>(quotationEntity);
                return Ok(quotationDto);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveQuotation(Guid id)
        {
            
            try
            {
               await quotationRepository.DeleteQuotation(id);
            }
            catch (Exception e)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> CreateQquotation(QuotationDto quotationDto)
        {
            Quotation quotation;
            try
            {
                if(quotationDto==null)
                    return BadRequest("Quotation object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model oject");
                quotation = _mapper.Map<Quotation>(quotationDto);
                await quotationRepository.CreateQuotation(quotation);
            }
            catch(Exception e)
            {
                return UnprocessableEntity("Quotation already exists!");
            }
            return CreatedAtAction("GetQuotationById", new { Id = quotation.Id }, quotation);
          
        }
        [HttpPatch("{id}")] 
        public async Task<IActionResult> Patch(Guid id,JsonPatchDocument<Quotation> quotation)
        {

            Quotation quotationUpdated;
            try
            {
                quotationUpdated =await quotationRepository.Patch(id, quotation);
            }
            catch
            {
                return NotFound($"Quotaton with Id={id} not found");
            }
            return Ok(quotationUpdated);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Quotation quotation)
        {
            if (id != quotation.Id)
                return BadRequest();
            try
            {
                await quotationRepository.Update(quotation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!quotationRepository.QuotationExists(quotation.Id))
                {
                    return NotFound($"Quotaton with Id= {id} not found");
                }
                else
                    throw;
            }
            return NoContent();
        }
    }
}
