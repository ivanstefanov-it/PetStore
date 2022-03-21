using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Toy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Implementations
{
    public class ToyService : IToyService
    {
        private const int PageSize = 9;
        private readonly PetStoreDbContext db;

        public ToyService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ToyListingServiceModel> All(int page = 1)
        {
            var allToys = this.db.
                Toys
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(x => new ToyListingServiceModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            })
                .ToList();

            return allToys;
        }

        public async Task<int> Create(string name, string decsription, decimal distributorPrice, decimal price, int brand, int category, string imageUrl)
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
                ImageUrl = imageUrl,
                BrandId = brandId,
                CategoryId = categoryId
            };

            await this.db.Toys.AddAsync(toy);
            await this.db.SaveChangesAsync();
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
                ImageUrl = x.ImageUrl
            }).FirstOrDefault();

            return model;
        }

        public int Total() => this.db.Toys.Count();
    }
}
