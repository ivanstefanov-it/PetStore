using PetStore.Data;
using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext db;

        public OrderService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public int Create(DateTime purchaseDate, OrderStatus status, string userId)
        {
            //var user = this.db.User.Where(x => x.Id == userId).FirstOrDefault();
            //userId from session?
            var order = new Order
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId
            };
                
            this.db.Orders.Add(order);
            this.db.SaveChanges();
            return order.Id;
        }

        public void OrderToy(int id)
        {

        }
    }
}
