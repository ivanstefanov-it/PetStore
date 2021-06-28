using PetStore.Services.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Order
{
    public class GetOrderViewModel
    {
        public OrderListingServiceModel Order { get; set; }
    }
}
