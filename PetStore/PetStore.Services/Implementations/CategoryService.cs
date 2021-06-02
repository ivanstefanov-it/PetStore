using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public int Create(string name, string description)
        {
            if (name == null)
            {
                throw new InvalidOperationException("Category name cannot be empty!");
            }

            if (this.db.Categories.Any(x => x.Name == name))
            {
                throw new InvalidOperationException($"Category name {name} already exists!");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Category name cannot be more than {DataValidation.NameMaxLength} symbols!");
            }

            var category = new Category
            {
                Name = name,
                Description = description,
            };

            this.db.Categories.Add(category);
            this.db.SaveChanges();
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
