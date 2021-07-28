using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Dossier
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }
}
