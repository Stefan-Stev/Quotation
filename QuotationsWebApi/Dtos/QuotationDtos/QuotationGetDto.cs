using QuotationsWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationsWebApi.Dtos
{
    public class QuotationGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid DossierId { get; set; }
        public Status Status { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DataUntilValid { get; set; }
    }
}
