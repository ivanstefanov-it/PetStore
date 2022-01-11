using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Web.ViewModels.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() 
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(BrandCreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            this.brandService.Create(input.Name);
            return this.Redirect(nameof(All));
        }

        public IActionResult All(int page = 1)
        {
            var allBrands = this.brandService.All(page);
            var totalBrands = this.brandService.Total();
            var model = new AllBrandsViewModel 
            {
                Brands = allBrands,
                Total = totalBrands,
                CurrentPage = page
            };
            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var brandDetails = this.brandService.Details(id);

            if (brandDetails == null)
            {
                return NotFound();
            }

            return this.View(brandDetails);
        }

        public IActionResult ComfirmDelete(int id)
        {
            var deleted = this.brandService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
