using PetStore.Data;
using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext db;

        public FoodService(PetStoreDbContext db)
        {
            this.db = db;
        }
        public int Create(string name, double weight, decimal distributorPrice, decimal price, DateTime expirationDate, string brand, string category)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Food name cannot be empty!");
            }

            if (this.db.Categories.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Food name {name} already exists!");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Food name cannot be more than {DataValidation.NameMaxLength} symbols!");
            }

            if (weight < 0)
            {
                throw new InvalidOperationException($"Weight should be more than 0kg!");
            }

            if (distributorPrice < 0)
            {
                throw new InvalidOperationException($"Distributor price should be more than 0$!");
            }

            if (price < 0)
            {
                throw new InvalidOperationException($"Price should be more than 0$!");
            }

            var brandId = this.db.Brands.Where(x => x.Name == brand).Select(x => x.Id).FirstOrDefault();
            var categoryId = this.db.Categories.Where(x => x.Name == category).Select(x => x.Id).FirstOrDefault();
            var food = new Food
            {
                Name = name,
                Weight = weight,
                DistributorPrice = distributorPrice,
                Price = price, 
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId,
            };

            this.db.Food.Add(food);
            this.db.SaveChanges();
            return food.Id;
        }
    }
}
