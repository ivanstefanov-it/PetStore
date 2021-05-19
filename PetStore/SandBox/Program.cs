using PetStore.Data;
using PetStore.Data.Models;
using System;
using System.Linq;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var data = new PetStoreDbContext())
            {
                
                for (int i = 0; i < 10; i++)
                {
                    var breed = new Breed();
                    breed.Name = "Breed" + i;
                    data.Breeds.Add(breed);
                }
                data.SaveChanges();

                for (int i = 0; i < 30; i++)
                {
                    var category = new Category
                    {
                        Name = "Category" + i,
                        Description = "Category Description" + i,
                    };

                    data.Categories.Add(category);
                }

                data.SaveChanges();

                for (int i = 0; i < 100; i++)
                {
                    var BreedId = data
                       .Breeds
                       .OrderBy(b => Guid.NewGuid())
                       .Select(b => b.Id)
                       .FirstOrDefault();

                    var categoryId = data
                        .Categories
                        .OrderBy(c => Guid.NewGuid())
                        .Select(c => c.Id)
                        .FirstOrDefault();

                    var pet = new Pet
                    {
                        DateOfBirth = DateTime.UtcNow.AddDays(-60 + i),
                        Price = 50 + i,
                        Gender = i % 2 == 0 ? Gender.Male : Gender.Female,
                        Description = $"Some randon description{i}",
                        CategoryId = categoryId,
                        BreedId = BreedId,
                    };
                    data.Pets.Add(pet);
                }

                data.SaveChanges();
            }
        }
    }
}
