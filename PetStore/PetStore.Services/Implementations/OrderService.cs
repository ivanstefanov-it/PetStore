﻿using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var allOrders = this.db.Orders.Where(x => x.Status == OrderStatus.Pending).Select(x => new OrderListingServiceModel
            {
                Id = x.Id,
                PurchaseDate = x.PurchaseDate,
                Status = x.Status
            }).ToList();

            return allOrders;
        }

        public async Task<int> Create(string userId)
        {
            var order = new Order
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId
            };

            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);

            await this.db.Orders.AddAsync(order);
            await this.db.SaveChangesAsync();
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

            order.Toys.Add(new ToyOrder() { Toy = toy });

            this.db.SaveChanges();
        }

        public void OrderFood(int foodId, string userId)
        {
            var food = this.db.Food.FirstOrDefault(x => x.Id == foodId);

            var order = new Order
            {
                PurchaseDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                UserId = userId,
            };
            this.db.Orders.Add(order);
            this.db.SaveChanges();

            order.Food.Add(new FoodOrder() { Food = food });

            this.db.SaveChanges();
        }

        public void Complete(int id)
        {
            var order = this.db.Orders.FirstOrDefault(x => x.Id == id);
            order.Status = OrderStatus.Done;

            this.db.SaveChanges();
        }

        public OrderListingServiceModel GetOrder(int id)
        {
            var order = this.db.Orders.Where(x => x.Id == id).Select(x => new OrderListingServiceModel
            {
                Id = x.Id,
                PurchaseDate = x.PurchaseDate,
                Status = x.Status
            }).FirstOrDefault();

            return order;
        }
    }
}
