using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Services.Implementations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PetStore.Tests
{
    public class BrandTests
    {
        [Fact]
        public async Task CreateBrandByNameShouldThrowExeptionWhenValueIsNull()
        {
            var brand = new BrandService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => brand.Create(null));
        }

        [Fact]
        public async Task CreateBrandByNameShouldThrowExeptionWhenValueIsMoreThan30Symbols()
        {
            var brand = new BrandService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => brand.Create("This is a very, very long name for this test"));
        }

        [Fact]
        public async Task CreateBrandByNameShouldThrowExeptionWhenValueIsLessThan2Symbols()
        {
            var brand = new BrandService(new PetStoreDbContext());
            await Assert.ThrowsAsync<InvalidOperationException>(() => brand.Create("hm"));
        }


    }
}
