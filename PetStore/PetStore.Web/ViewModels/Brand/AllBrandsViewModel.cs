using PetStore.Services.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Brand
{
    public class AllBrandsViewModel
    {
        public IEnumerable<BrandListingServiceModel> Brands { get; set; }
    }
}
