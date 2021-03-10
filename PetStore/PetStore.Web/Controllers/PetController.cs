using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Web.ViewModels.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService petService;

        public PetController(IPetService petService)
        {
            this.petService = petService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AddPetInputMode inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.petService.Create(inputModel.Gender, inputModel.DateOfBirth,  inputModel.Price, inputModel.Description, inputModel.BreedId, inputModel.CategoryId);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All()
        {
            var allPets = this.petService.All();
            var model = new AllPetsViewModel{ Pets = allPets };
            return this.View(model);
        }

        public IActionResult Delete(int id)
        {
            var pet = this.petService.Details(id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        public IActionResult ComfirmDelete(int id)
        {
            var deleted = this.petService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
