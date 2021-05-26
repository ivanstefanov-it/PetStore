using PetStore.Services.Models.Toy;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IToyService
    {
        int Create(string name, string decsription, decimal distributorPrice, decimal price, int brand, int category);

        IEnumerable<ToyListingServiceModel> All(int page = 1);

        ToyDetailsServiceModel Details(int id);

        bool Delete(int id);

        int Total();

        ToyOrderListingServiceModel Order(int id);
    }
}
