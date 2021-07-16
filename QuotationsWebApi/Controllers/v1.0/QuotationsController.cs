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
    [ApiVersion("1.0")]
    public class QuotationsController : BaseApiController
    {
        private readonly IQuotationRepository quotationRepository;
       

        public QuotationsController(IQuotationRepository quotationRepository, IMapper mapper):base(mapper)
        {
            this.quotationRepository = quotationRepository;
        }

        [HttpGet]
        public async Task<ActionResult <List<Quotation>>> GetQuotations()
        {
            List<Quotation> listOfQuotations = await quotationRepository.GetAllQuotations();
            List<QuotationGetDto> listOfQuotationsDto = new();
            foreach(var quotationEntity in listOfQuotations)
            {
                listOfQuotationsDto.Add(_mapper.Map<QuotationGetDto>(quotationEntity));
            }
            return Ok(listOfQuotationsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuotationForCreationDto>> GetQuotationById(Guid id)
        {
            try
            {
                Quotation quotationEntity = await quotationRepository.GetQuotationById(id);
                var quotationDto = _mapper.Map<QuotationGetDto>(quotationEntity);
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
        public async Task<ActionResult> CreateQuotation(QuotationForCreationDto quotationDto)
        {
            Quotation quotation;
            QuotationGetDto quotationGetDto;
            try
            {
                if(quotationDto == null)
                    return BadRequest("Quotation object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model oject");
                quotation = _mapper.Map<Quotation>(quotationDto);
                await quotationRepository.CreateQuotation(quotation);
                quotationGetDto = _mapper.Map<QuotationGetDto>(quotation);
            }
            catch(Exception e)
            {
                return UnprocessableEntity("Quotation already exists!");
            }
            return CreatedAtAction("GetQuotationById", new { Id = quotation.Id }, quotationGetDto);
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
            if (!quotationRepository.QuotationExists(quotation.Id))
            {
                return NotFound($"Quotaton with Id= {id} not found");
            }
            try
            {
                await quotationRepository.Update(quotation);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            return NoContent();
        }
    }
}
