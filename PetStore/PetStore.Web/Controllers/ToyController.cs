﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Web.ViewModels.Toy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class ToyController : Controller
    {
        private readonly IToyService toyService;

        public ToyController(IToyService toyService)
        {
            this.toyService = toyService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ToyCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            this.toyService.Create(inputModel.Name, inputModel.Description, inputModel.DistributorPrice, inputModel.Price, inputModel.BrandId, inputModel.CategoryId, inputModel.ImageUrl);
            return RedirectToAction(nameof(All));
        }

        public IActionResult All(int page = 1)
        {
            var allToys = this.toyService.All(page);
            var totalToys = this.toyService.Total();

            var model = new AllToysViewModel 
            { 
                Toys = allToys,
                Total = totalToys,
                CurrentPage = page
            };
            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var toyDetails = this.toyService.Details(id);

            if (toyDetails == null)
            {
                return this.NotFound();
            }

            return this.View(toyDetails);
        }

        public IActionResult ComfirmDelete(int id)
        {
            var deleted = this.toyService.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Order(int id)
        {
            var toyDetails = this.toyService.Order(id);

            if (toyDetails == null)
            {
                return this.NotFound();
            }

            return this.View(toyDetails);
        }
    }
}
