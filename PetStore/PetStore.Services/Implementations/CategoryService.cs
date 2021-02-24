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
        private readonly PetStoreDbContext db;

        public CategoryService(PetStoreDbContext db)
        {
            this.db = db;
        }

        public int Create(CategoryCreateServiceModel model)
        {
            if (model.Name == null)
            {
                throw new InvalidOperationException("Breed name cannot be empty!");
            }

            if (this.db.Categories.Any(x => x.Name == model.Name))
            {
                throw new InvalidOperationException($"Breed name {model.Name} already exists!");
            }

            if (model.Name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Breed name cannot be more than {DataValidation.NameMaxLength} symbols!");
            }

            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,
            };

            this.db.Categories.Add(category);
            this.db.SaveChanges();
            return category.Id;
        }
    }
}
