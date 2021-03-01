using Microsoft.AspNetCore.Mvc;
using PetStore.Web.ViewModels.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class FoodController : Controller
    {
        public FoodController()
        {

        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(FoodCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            //this.foodService
            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            return this.View();
        }
    }
}
