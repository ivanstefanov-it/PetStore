using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Food
{
    public class FoodListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
