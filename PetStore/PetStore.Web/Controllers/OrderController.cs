using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetStore.Data.Models;
using PetStore.Services;
using PetStore.Services.Models.Order;
using PetStore.Web.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderController(IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            this.orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult CreateToyOrder(int Id)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            this.orderService.OrderToy(Id, userId);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult CreateFoodOrder(int Id)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            this.orderService.OrderFood(Id, userId);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var allOrders = this.orderService.All();
            var model = new AllOrdersViewModel { Orders = allOrders };
            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Complete(int id)
        {
            this.orderService.Complete(id);
            var order = this.orderService.GetOrder(id);
            var model = new GetOrderViewModel { Order = order };
            return this.View(model);
        }
    }
}
