using QuotationsWebApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace QuotationsWebApi.Dtos
{
    public class DossierForCreationUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters")]
        public string Name { get; set; }
        [RangeUntilCurrentYear(1900, ErrorMessage = "Please enter a valid year")]
        public int Year { get; set; }
    }
}
