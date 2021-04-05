using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Order;
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

        public IEnumerable<OrderListingServiceModel> All()
        {
            var allOrders = this.db.Orders.Select(x => new OrderListingServiceModel
            {
                Id = x.Id,
                PurchaseDate = x.PurchaseDate,
                Status = x.Status
            }).ToList();

            return allOrders;
        }

        public int Create(string userId)
        {
            var order = new Order
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId
            };

            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);
                
            this.db.Orders.Add(order);
            this.db.SaveChanges();
            return order.Id;
        }

        public void OrderToy(int toyId, string userId)
        {
            var toy = this.db.Toys.FirstOrDefault(x => x.Id == toyId);

            var order = new Order
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId,
            };
            this.db.Orders.Add(order);
            this.db.SaveChanges();

            order.Toys.Add(new ToyOrder() { Toy = toy});

            this.db.SaveChanges();
        }
    }
}
