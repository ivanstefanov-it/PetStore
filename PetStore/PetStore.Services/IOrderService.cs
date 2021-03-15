using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IOrderService
    {
        int Create(DateTime purchaseDate, OrderStatus status, string userId);


        void OrderToy(int id);
    }
}
