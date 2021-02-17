namespace PetStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatus Status { get; set; }

        public string UserId { get; set; }

        public StoreUser User { get; set; }

        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public ICollection<FoodOrder> Food { get; set; } = new HashSet<FoodOrder>();

        public ICollection<ToyOrder> Toys { get; set; } = new HashSet<ToyOrder>();
    }
}
