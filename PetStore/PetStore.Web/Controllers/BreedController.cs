﻿using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(BreedCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.breedService.Create(input.Name);

            return this.Redirect(nameof(All));
        }

        public IActionResult All(int page = 1)
        {
            var allBreeds = this.breedService.All(page);
            var totalBreeds = this.breedService.Total();
            var model = new AllBreedViewModel 
            { 
                Breeds = allBreeds,
                Total = totalBreeds,
                CurrentPage = page
            };
            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var breedDetails = this.breedService.Details(id);

            if (breedDetails == null)
            {
                return NotFound();
            }

            return this.View(breedDetails);
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
