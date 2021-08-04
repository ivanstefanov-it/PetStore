using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Toy
{
    public class ToyOrderListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
