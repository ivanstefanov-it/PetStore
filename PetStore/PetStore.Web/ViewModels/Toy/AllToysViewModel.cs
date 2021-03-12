using PetStore.Services.Models.Toy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Toy
{
    public class AllToysViewModel
    {
        public IEnumerable<ToyListingServiceModel> Toys { get; set; }
    }
}
