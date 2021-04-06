using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Food
{
    public class FoodOrderListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
