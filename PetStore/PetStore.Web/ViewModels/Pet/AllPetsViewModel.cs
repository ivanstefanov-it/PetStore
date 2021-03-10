using PetStore.Services.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Pet
{
    public class AllPetsViewModel
    {
        public IEnumerable<PetLIstingServiceModel> Pets { get; set; }
    }
}
