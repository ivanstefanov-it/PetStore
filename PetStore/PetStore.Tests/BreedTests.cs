using PetStore.Data;
using PetStore.Services;
using PetStore.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PetStore.Tests
{
    public class BreedTests
    {
        [Fact]
        public async Task CreateBreedByNameShouldThrowExeptionWhenValueIsNull()
        {
            var breed = new BreedService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => breed.Create(null));
        }

        [Fact]
        public async Task CreateBreedByNameShouldThrowExeptionWhenValueIsMoreThan30Symbols()
        {
            var breed = new BreedService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => breed.Create("This is a very, very long name for this test"));
        }

        [Fact]
        public async Task CreateBreedByNameShouldThrowExeptionWhenValueIsLessThan2Symbols()
        {
            var breed = new BreedService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => breed.Create("hm"));
        }
    }
}
