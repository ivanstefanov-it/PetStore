using PetStore.Services.Models.Breed;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IBreedService
    {
        int Create(string name);

        IEnumerable<BreedListingServiceModel> All();

        bool Delete(int id);

        BreedDetailsListingModel Details(int id);
    }
}
