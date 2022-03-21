using PetStore.Data.Models;
using PetStore.Services.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Services
{
    public interface IOrderService
    {
        Task<int> Create(string userId);

        IEnumerable<OrderListingServiceModel> All();

        void OrderToy(int toyId, string userId);

        void OrderFood(int toyId, string userId);

        void Complete(int id);

        OrderListingServiceModel GetOrder(int id);
    }
}
