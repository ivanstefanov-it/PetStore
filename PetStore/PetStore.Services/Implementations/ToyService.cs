using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Toy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services.Implementations
{
    public class ToyService : IToyService
    {
        private readonly PetStoreDbContext db;

        public ToyService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ToyListingServiceModel> All()
        {
            var allToys = this.db.Toys.Select(x => new ToyListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToList();

            return allToys;
        }

        public int Create(string name, string decsription, decimal distributorPrice, decimal price, int brand, int category)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Toy name cannot be empty!");
            }
            if (this.db.Toys.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Toy name {name} already exists!");
            }
            if (decsription.Length < 10)
            {
                throw new InvalidOperationException($"Toy decsription cannot be less than 10 symbols!");
            }
            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Toy name cannot be more than {DataValidation.NameMaxLength} symbols!");
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

            var toy = new Toy
            {
                Name = name,
                Price = price,
                DistributorPrice = distributorPrice,
                Description = decsription,
                BrandId = brandId,
                CategoryId = categoryId
            };
            this.db.Toys.Add(toy);
            this.db.SaveChanges();
            return toy.Id;
        }

        public bool Delete(int id)
        {
            var toy = this.db.Toys.Find(id);

            if (toy == null)
            {
                return false;
            }

            this.db.Toys.Remove(toy);
            this.db.SaveChanges();

            return true;
        }

        public ToyDetailsServiceModel Details(int id)
        {
            var model = this.db.Toys.Where(x => x.Id == id).Select(x => new ToyDetailsServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            }).FirstOrDefault();

            return model;
        }

        public ToyOrderListingServiceModel Order(int id)
        {
            var model = this.db.Toys.Where(x => x.Id == id).Select(x => new ToyOrderListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            }).FirstOrDefault();

            return model;
        }
    }
}
