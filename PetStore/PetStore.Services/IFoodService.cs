using PetStore.Services.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IFoodService
    {
        int Create(string name, double weight, decimal distributorPrice, decimal price, DateTime expirationDate, int brand, int category, string imageUrl);

        IEnumerable<FoodListingServiceModel> All(int page = 1);

        FoodDetailsServiceModel Details(int id);

        bool Delete(int id);

        int Total();

        FoodOrderListingServiceModel Order(int id);
    }
}
