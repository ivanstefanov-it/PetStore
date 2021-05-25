using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Services;
using PetStore.Web.ViewModels.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodService foodService;

        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
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
            
            this.foodService.Create(inputModel.Name, inputModel.Weight, inputModel.DistributorPrice, inputModel.Price, inputModel.ExpirationDate, inputModel.BrandId, inputModel.CategoryId);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All(int page = 1)
        {
            var allFoods = this.foodService.All();
            var totalFood = this.foodService.Total();
            
            var model = new AllFoodsViewModel 
            { 
                Foods = allFoods,
                Total = totalFood,
                CurrentPage = page
            };
            return this.View(model);
        }

        public IActionResult Delete(int id)
        {
            var foodDetails = this.foodService.Details(id);

            if (foodDetails == null)
            {
                return this.NotFound();
            }

            return this.View(foodDetails);
        }

        public IActionResult ComfirmDelete(int id)
        {
            var deleted = this.foodService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Order(int id)
        {
            var foodDetails = this.foodService.Order(id);

            if (foodDetails == null)
            {
                return this.NotFound();
            }

            return this.View(foodDetails);
        }
    }
}
