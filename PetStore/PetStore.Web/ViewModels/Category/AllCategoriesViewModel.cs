using PetStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Category
{
    public class AllCategoriesViewModel
    {
        public IEnumerable<CategoryListingServiceModel> Categories { get; set; }
    }
}
