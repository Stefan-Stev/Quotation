using System;

namespace QuotationsWebApi.Entities
{
    public class Quotation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DossierId { get; set; }
        public float Price { get; set; }
        public Status Status { get; set; } 
        public DateTime DataCreated { get; set; }
        public DateTime DataUntilValid { get; set; }
    }
}
