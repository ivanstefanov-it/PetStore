using PetStore.Data.Models;
using PetStore.Services.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IOrderService
    {
        int Create(string userId);

        IEnumerable<OrderListingServiceModel> All();

        void OrderToy(int toyId, string userId);

        void OrderFood(int toyId, string userId);

        void Complete(int id);

        OrderListingServiceModel GetOrder(int id);
    }
}
