using PetStore;
using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext db;

        public BrandService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public int Create(string name)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Brand name cannot be empty!");
            }

            if (this.db.Brands.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Brand name {name} already exists!");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {DataValidation.NameMaxLength} symbols!");
            }

            var brand = new Brand { Name = name };

            this.db.Brands.Add(brand);
            this.db.SaveChanges();

            return brand.Id;
        }

        public IEnumerable<BrandListingServiceModel> All()
        {
            var allBrands = this.db.Brands.Select(x =>  new BrandListingServiceModel
            { 
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return allBrands;
        }

        public bool Delete(int id)
        {
            var brand = this.db.Brands.Find(id);

            if (brand == null)
            {
                return false;
            }

            this.db.Brands.Remove(brand);
            this.db.SaveChanges();

            return true;
        }

        public BrandDetailsServiceModel Details(int id)
        {
            var brandDetails = this.db.Brands
                .Where(x => x.Id == id)
                .Select(x => new BrandDetailsServiceModel
            {
                Name = x.Name,
                Id = x.Id
                
            }).FirstOrDefault();

            return brandDetails;
        }
    }
}
