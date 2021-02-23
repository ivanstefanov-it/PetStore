using PetStore.Services.Models.Breed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Breed
{
    public class AllBreedViewModel
    {
        public IEnumerable<BreedListingServiceModel> Breeds { get; set; }
    }
}
