using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult MyOrders()
        {
            return this.View();
        }


    }
}
