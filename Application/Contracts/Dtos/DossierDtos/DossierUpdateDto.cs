using System;

namespace Application.Contracts.Dtos.DossierDtos
{
    public class DossierUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
