using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Pet
{
    public class AddPetInputMode
    {
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Range(0, 15000)]
        public decimal Price { get; set; }

        [MinLength(10, ErrorMessage = "{0} should be more than {1} symbols!")]
        public string Description { get; set; }

        public int BreedId { get; set; }

        public int CategoryId { get; set; }
    }
}
