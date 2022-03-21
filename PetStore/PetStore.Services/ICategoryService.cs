using PetStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        Task<int> Create(string name, string description);

        IEnumerable<CategoryListingServiceModel> All(int page = 1);

        CategoryDetailsServiceModel Details(int id);

        int Total();

        bool Delete(int id);
    }
}
