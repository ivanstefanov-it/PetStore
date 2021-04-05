using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Order
{
    public class OrderListingServiceModel
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        //string?
        public OrderStatus Status { get; set; }
    }
}
