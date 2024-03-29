﻿using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private const int PageSize = 9;
        private readonly PetStoreDbContext db;

        public CategoryService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryListingServiceModel> All(int page = 1)
        {
            var allCategories = this.db
                .Categories
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(x => new CategoryListingServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();

            return allCategories;
        }

        public async Task<int> Create(string name, string description)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Category name cannot be empty!");
            }

            if (description == null)
            {
                throw new InvalidOperationException("Description cannot be empty!");
            }

            if (this.db.Categories.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Category name {name} already exists!");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Category name cannot be more than {DataValidation.NameMaxLength} symbols!");
            }

            if (name.Length > DataValidation.NameMinLength)
            {
                throw new InvalidOperationException($"Category name cannot be less than {DataValidation.NameMinLength} symbols!");
            }

            if (description.Length > DataValidation.DescriptionMaxLength)
            {
                throw new InvalidOperationException($"Description cannot be more than {DataValidation.DescriptionMaxLength} symbols!");
            }

            if (description.Length > DataValidation.NameMinLength)
            {
                throw new InvalidOperationException($"Description cannot be less than {DataValidation.NameMinLength} symbols!");
            }

            var category = new Category
            {
                Name = name,
                Description = description,
            };

            await this.db.Categories.AddAsync(category);
            await this.db.SaveChangesAsync();
            return category.Id;
        }

        public bool Delete(int id)
        {
            var category = this.db.Categories.Find(id);

            if (category == null)
            {
                return false;
            }

            this.db.Categories.Remove(category);
            this.db.SaveChanges();

            return true;
        }

        public CategoryDetailsServiceModel Details(int id)
        {
            var category = this.db.Categories
                .Where(x => x.Id == id)
                .Select(x => new CategoryDetailsServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }).FirstOrDefault();

            return category;
        }

        public int Total() => this.db.Categories.Count();
    }
}
