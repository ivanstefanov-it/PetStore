using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Web.ViewModels.Breed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedService breedService;

        public BreedController(IBreedService breedService)
        {
            this.breedService = breedService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.breedService.Create(input.Name);

            return this.Redirect(nameof(All));
        }

        public IActionResult All()
        {
            var allBreeds = this.breedService.All();
            var model = new AllBreedViewModel { Breeds = allBreeds };
            return this.View(model);
        }

        public IActionResult Delete(int id)
        {
            var breed = this.breedService.Details(id);

            if (breed == null)
            {
                return NotFound();
            }

            return this.View(breed);
        }

        public IActionResult ComfirmDelete(int id)
        {
            var deleted =  this.breedService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
