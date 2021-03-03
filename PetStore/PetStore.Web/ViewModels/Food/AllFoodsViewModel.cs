using PetStore.Services.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Food
{
    public class AllFoodsViewModel
    {
        public IEnumerable<FoodListingServiceModel> Foods { get; set; }
    }
}
