using System;
using System.Text.Json.Serialization;

namespace QuotationsWebApi.Entities
{
    public class Quotation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DossierId { get; set; }

        [JsonIgnore]
        public Dossier CurrentDossier { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime ValidUntilDate { get; set; } 
    }
}
