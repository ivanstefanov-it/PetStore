using PetStore.Data;
using PetStore.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetStore.Tests
{
    public class CateroryTests
    {
        [Fact]
        public async Task CreateCategoryByNameShouldThrowExeptionWhenNameIsNull()
        {
            var category = new CategoryService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => category.Create(null, null));
        }

        [Fact]
        public async Task CreateCategoryByNameShouldThrowExeptionWhenNameIsMoreThan30Symbols()
        {
            var category = new CategoryService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => category.Create("This is a very, very long name for this test", "description"));
        }

        [Fact]
        public async Task CreateCategoryByNameShouldThrowExeptionWhenNameIsLessThan2Symbols()
        {
            var category = new CategoryService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => category.Create("hm", "description"));
        }

        [Fact]
        public async Task CreateCategoryByNameShouldThrowExeptionWhenDescriptionIsLessThan2Symbols()
        {
            var category = new CategoryService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => category.Create("Name", "de"));
        }

        [Fact]
        public async Task CreateCategoryByNameShouldThrowExeptionWhenDescriptionAndNameAreLessThan2Symbols()
        {
            var category = new CategoryService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => category.Create("Hm", "de"));
        }
    }
}
