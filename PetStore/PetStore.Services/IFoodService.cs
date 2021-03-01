using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IFoodService
    {
        int Create(string name, double weight, decimal distributorPrice, decimal price, DateTime expirationDate, string brand, string category);
    }
}
