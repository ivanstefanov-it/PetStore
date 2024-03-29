﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Pet
{
    public class PetListingServiceModel
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        public string Breed { get; set; }

        public decimal Price { get; set; }
    }
}
