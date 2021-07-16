using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotationsWebApi.Dtos;
using QuotationsWebApi.Entities;
using QuotationsWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationsWebApi.Controllers.v1._0
{
    [ApiVersion("1.0")]
    public class DossiersController:BaseApiController
    {
        private readonly IDossierRepository dossierRepository;

        public DossiersController(IDossierRepository dossierRepository, IMapper mapper) : base(mapper)
        {
            this.dossierRepository = dossierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dossier>>> GetDossiers()
        {
            var dossiers = await dossierRepository.GetAllDossier();
            List<DossierGetDto> listOfDossiersDto = new();
            foreach( var dossier in dossiers)
                {
                var listOfQuotations = dossier.Quotations.Select(quotation => _mapper.Map<QuotationGetDto>(quotation)).ToList();
                DossierGetDto dossierDto = new DossierGetDto();
                dossierDto.Id = dossier.Id;
                dossierDto.Name = dossier.Name;
                dossierDto.Year = dossier.Year;
                dossierDto.Quotations = listOfQuotations;
                listOfDossiersDto.Add(dossierDto);
                }
            return Ok(listOfDossiersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DossierGetDto>> GetDossierById(Guid id)
        {
            try
            {
                Dossier dossierEntity = await dossierRepository.GetDossierById(id);
                var listOfQuotations = dossierEntity.Quotations
                                      .Select(quotation => _mapper.Map<QuotationGetDto>(quotation)).ToList();
                DossierGetDto dossierDto = new DossierGetDto();
                dossierDto.Id = dossierEntity.Id;
                dossierDto.Name = dossierEntity.Name;
                dossierDto.Year = dossierEntity.Year;
                dossierDto.Quotations = listOfQuotations;
                return Ok(dossierDto);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveDossier(Guid id)
        {

            try
            {
                await dossierRepository.DeleteDossier(id);
            }
            catch (Exception e)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateDossier(DossierForCreationUpdateDto dossierDto)
        {
            Dossier dossier;
            try
            {
                if (dossierDto == null)
                    return BadRequest("Dossier object is null");
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model oject");
                dossier = _mapper.Map<Dossier>(dossierDto);
                await dossierRepository.CreateDossier(dossier);
            }
            catch (Exception e)
            {
                return UnprocessableEntity("Dossier already exists!");
            }
            return CreatedAtAction("GetDossierById", new { Id = dossier.Id }, dossier);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, DossierUpdateDto dossierDto)
        {
            if (id != dossierDto.Id)
                return BadRequest();
            if (!dossierRepository.DossierExists(dossierDto.Id))
            {
                return NotFound($"Dossier with Id= {id} not found");
            }
            try
            {
                var dossier = _mapper.Map<Dossier>(dossierDto);
                await dossierRepository.Update(dossier);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            return NoContent();
        }
    }
}
