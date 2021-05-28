using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.categoryService.Create(inputModel.Name, inputModel.Description);
            return this.Redirect(nameof(All));
        }

        public IActionResult All(int page = 1)
        {
            var allCategories = this.categoryService.All(page);
            var totalCategories = this.categoryService.Total();

            var model = new AllCategoriesViewModel 
            { 
                Categories = allCategories,
                Total = totalCategories,
                CurrentPage = page
            };

            return this.View(model);
        }

        public IActionResult Delete(int id)
        {
            var categoryDetails = this.categoryService.Details(id);

            if (categoryDetails == null)
            {
                return this.NotFound();
            }

            return this.View(categoryDetails);
        }

        public IActionResult ComfirmDelete(int id)
        {
            var deleted = this.categoryService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
