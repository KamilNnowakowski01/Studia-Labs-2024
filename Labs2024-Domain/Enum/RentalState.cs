
using System.ComponentModel.DataAnnotations;

namespace Labs2024_Domain.Models
{
    public enum RentalState
    {
        [Display(Name = "Rented")]
        Rented,

        [Display(Name = "Returned")]
        Returned
    }
}