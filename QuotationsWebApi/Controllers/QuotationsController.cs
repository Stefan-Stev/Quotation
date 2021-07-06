using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Quotation> GetAllQuotationById(Guid id)
        {
            return Ok(quotationRepository.GetById(id));
        }
        [HttpDelete]
        public async Task<ActionResult> RemoveQuotation(Guid id)
        {
            quotationRepository.Delete(id);
            return Ok();
        }
        [HttpPost]
        public void CreateQquotation(Quotation quotation)
        {
            quotationRepository.Create(quotation);
          
        }
        [HttpPut] 
        public void UpdateQuotation(Quotation quotation)
        {
            quotationRepository.Update(quotation);
        }
    }
}
