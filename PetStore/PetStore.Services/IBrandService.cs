using PetStore.Services.Models.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> All();

        bool Delete(int id);

        BrandDetailsServiceModel Details(int id);

    }
}
