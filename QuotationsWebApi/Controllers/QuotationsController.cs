using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public QuotationsController(IQuotationRepository quotationRepository)
        {
            this.quotationRepository = quotationRepository;
        }
        [HttpGet]
        public ActionResult <List<Quotation>> GetQuotations()
        {
            return Ok(quotationRepository.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Quotation> GetQuotationById(Guid id)
        {
            try
            {
                return Ok(quotationRepository.GetById(id));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public IActionResult RemoveQuotation(Guid id)
        {
            try
            {
                quotationRepository.Delete(id);
            }
            catch (Exception e)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public ActionResult CreateQquotation(Quotation quotation)
        {
            try
            {
                quotationRepository.Create(quotation);
            }
            catch(Exception e)
            {
                return UnprocessableEntity("Quotation already exists!");
            }
            return CreatedAtAction("GetQuotationById", new { Id = quotation.Id }, quotation);
          
        }
        [HttpPatch("{id}")] 
        public IActionResult Patch(Guid id,JsonPatchDocument<Quotation> quotation)
        {
            
            Quotation quotationUpdated = new Quotation();
            try
            {
                quotationUpdated =quotationRepository.Patch(id, quotation);
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
                quotationRepository.Update(quotation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!quotationRepository.QuotationExists(quotation.Id))
                {
                    return NotFound();
                }
                else
                    throw;
            }
            return NoContent();
        }
    }
}
