using QuotationsWebApi.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace QuotationsWebApi.Dtos
{
    public class QuotationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]

        public string Name { get; set; }
        public Guid DossierId { get; set; }

        [Range(0.1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0.1}")]
        public float Price { get; set; }
        public Status Status { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DataUntilValid { get; set; }
    }
}
