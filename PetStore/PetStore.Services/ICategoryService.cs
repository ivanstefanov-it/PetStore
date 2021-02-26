using PetStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        int Create(string name, string description);

        IEnumerable<CategoryListingServiceModel> All();

        CategoryDetailsServiceModel Details(int id);

        bool Delete(int id);
    }
}
