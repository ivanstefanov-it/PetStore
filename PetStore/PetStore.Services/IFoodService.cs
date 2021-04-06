using PetStore.Services.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IFoodService
    {
        int Create(string name, double weight, decimal distributorPrice, decimal price, DateTime expirationDate, int brand, int category);

        IEnumerable<FoodListingServiceModel> All();

        FoodDetailsServiceModel Details(int id);

        bool Delete(int id);


        FoodOrderListingServiceModel Order(int id);
    }
}
