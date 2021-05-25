using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private const int PetsPageSize = 9;
        private readonly PetStoreDbContext db;

        public FoodService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<FoodListingServiceModel> All(int page = 1)
        {
            var allFoods = this.db.Food
                .Skip((page - 1) * PetsPageSize)
                .Take(PetsPageSize).Select(x => new FoodListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Weight = x.Weight,
                ExpirationDate = x.ExpirationDate,
            }).ToList();

            return allFoods;
        }

        public int Create(string name, double weight, decimal distributorPrice, decimal price, DateTime expirationDate, int brand, int category)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Food name cannot be empty!");
            }

            if (this.db.Food.Any(x => x.Name == name))
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
            
            var brandId = this.db.Brands.Where(x => x.Id == brand).Select(x => x.Id).FirstOrDefault();
            var categoryId = this.db.Categories.Where(x => x.Id == category).Select(x => x.Id).FirstOrDefault();
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

        public bool Delete(int id)
        {
            var food = this.db.Food.Find(id);

            if (food == null)
            {
                return false;
            }

            this.db.Food.Remove(food);
            this.db.SaveChanges();

            return true;
        }

        public FoodDetailsServiceModel Details(int id)
        {
            var model = this.db.Food.Where(x => x.Id == id).Select(x => new FoodDetailsServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Weight = x.Weight,
            }).FirstOrDefault();

            return model;
        }

        public FoodOrderListingServiceModel Order(int id)
        {
            var model = this.db.Food.Where(x => x.Id == id).Select(x => new FoodOrderListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            }).FirstOrDefault();

            return model;
        }

        public int Total() => this.db.Food.Count();
    }
}
