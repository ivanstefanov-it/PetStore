﻿using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Implementations
{
    public class PetService : IPetService
    {
        private const int PageSize = 9;
        private readonly PetStoreDbContext db;

        public PetService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PetListingServiceModel> All(int page = 1)
        {
            var allPets = this.db
                .Pets
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(p => new PetListingServiceModel
                {
                    Id = p.Id,
                    Breed = p.Breed.Name,
                    Price = p.Price,
                    Gender = p.Gender.ToString(),
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name,
                })
                .ToList();

            return allPets;
        }

        public async Task<int> Create(Gender gender, DateTime dateOfBirth, decimal price, string description, int breed, int category, string imageUrl)
        {
            
            if (description.Length < 10)
            {
                throw new InvalidOperationException($"Descriprion should be more than {10} symbols!!");
            }

            if (price < 0)
            {
                throw new InvalidOperationException($"Price should be more than 0$!");
            }

            var breedId = this.db.Breeds.Where(x => x.Id == breed).Select(x => x.Id).FirstOrDefault();
            var categoryId = this.db.Categories.Where(x => x.Id == category).Select(x => x.Id).FirstOrDefault();

            var pet = new Pet
            {
                Gender = gender,
                DateOfBirth = dateOfBirth,
                Price = price,
                Description = description,
                BreedId = breedId,
                CategoryId = categoryId,
                ImageUrl = imageUrl
            };

            await this.db.Pets.AddAsync(pet);
            await this.db.SaveChangesAsync();
            return pet.Id;
        }

        public bool Delete(int id)
        {
            var pet = this.db.Pets.Find(id);

            if (pet == null)
            {
                return false;
            }

            this.db.Pets.Remove(pet);
            this.db.SaveChanges();

            return true;
        }


        public PetDetailsServiceModel Details(int id)
        {
            var petDetails = this.db
            .Pets
            .Where(p => p.Id == id)
            .Select(p => new PetDetailsServiceModel
            {
                Id = p.Id,
                Breed = p.Breed.Name,
                Category = p.Category.Name,
                DateOfBirth = p.DateOfBirth,
                Description = p.Description,
                Gender = p.Gender,
                Price = p.Price
            })
            .FirstOrDefault();

            return petDetails;
        }

        public PetOrderServiceModel Order(int id)
        {
            var model = this.db.Pets.Where(x => x.Id == id).Select(x => new PetOrderServiceModel
            {
                Id = x.Id,
                Gender = x.Gender,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
            }).FirstOrDefault();

            return model;
        }

        public int Total() => this.db.Pets.Count();
    }
}
