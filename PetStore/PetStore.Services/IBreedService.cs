using PetStore.Services.Models.Breed;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IBreedService
    {
        int Create(string name);

        IEnumerable<BreedListingServiceModel> All(int page = 1);

        bool Delete(int id);

        int Total();
        BreedDetailsListingModel Details(int id);
    }
}
