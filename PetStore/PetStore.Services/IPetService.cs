using PetStore.Data.Models;
using PetStore.Services.Models.Pet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services
{
    public interface IPetService
    {
        Task<int> Create(Gender gender, DateTime dateOfBirth, decimal price, string description, int breedId, int categoryId, string imageUrl);

        IEnumerable<PetListingServiceModel> All(int page = 1);

        PetDetailsServiceModel Details(int id);

        bool Delete(int id);

        int Total();

        PetOrderServiceModel Order(int id);
    }
}
