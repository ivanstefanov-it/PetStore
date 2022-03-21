using PetStore.Services.Models.Brand;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services
{
    public interface IBrandService
    {
        Task<int> Create(string name);

        IEnumerable<BrandListingServiceModel> All(int page = 1);

        bool Delete(int id);

        int Total();

        BrandDetailsServiceModel Details(int id);

    }
}
