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

        public IActionResult Create() 
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }
            return this.Redirect("/Brand/All");
        }
    }
}
