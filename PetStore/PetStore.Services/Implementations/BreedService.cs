using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Breed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Services.Implementations
{
    public class BreedService : IBreedService
    {
        private const int PageSize = 9;
        private readonly PetStoreDbContext db;

        public BreedService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BreedListingServiceModel> All(int page = 1)
        {
            var allBreeds = this.db
                .Breeds
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(x => new BreedListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return allBreeds;
        }

        public int Create(string name)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Breed name cannot be empty!");
            }

            if (this.db.Breeds.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Breed name {name} already exists!");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Breed name cannot be more than {DataValidation.NameMaxLength} symbols!");
            }

            var breed = new Breed { Name = name };
            this.db.Breeds.Add(breed);
            this.db.SaveChanges();

            return breed.Id;
        }

        public bool Delete(int id)
        {
            var breed = this.db.Breeds.Find(id);

            if (breed == null)
            {
                return false;
            }

            this.db.Breeds.Remove(breed);
            this.db.SaveChanges();

            return true;
        }

        public BreedDetailsListingModel Details(int id)
        {
            var breedDetails = this.db.Breeds
                .Where(x => x.Id == id)
                .Select(x => new BreedDetailsListingModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefault();

            return breedDetails;
        }

        public int Total() => this.db.Breeds.Count();
    }
}
