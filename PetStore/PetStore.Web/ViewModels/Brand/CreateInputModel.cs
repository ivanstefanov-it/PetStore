using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Brand
{
    public class CreateInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
