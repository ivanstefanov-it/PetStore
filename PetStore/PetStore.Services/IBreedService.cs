using PetStore.Services.Models.Breed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services
{
    public interface IBreedService
    {
        Task<int> Create(string name);

        IEnumerable<BreedListingServiceModel> All(int page = 1);

        bool Delete(int id);

        int Total();
        BreedDetailsListingModel Details(int id);
    }
}
