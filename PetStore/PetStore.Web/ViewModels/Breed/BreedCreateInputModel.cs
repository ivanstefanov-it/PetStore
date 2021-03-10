using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Breed
{
    public class BreedCreateInputModel
    {
        [Required()]
        [MinLength(3, ErrorMessage = "{0} should be more than {1} symbols!")]
        public string Name { get; set; }
    }
}
