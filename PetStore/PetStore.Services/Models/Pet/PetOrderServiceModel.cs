using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Pet
{
    public class PetOrderServiceModel
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
