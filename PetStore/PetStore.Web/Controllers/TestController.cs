using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly UserManager<StoreUser> userManager;
        private readonly SignInManager<StoreUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TestController(UserManager<StoreUser> userManager,
            SignInManager<StoreUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> CreateUser()
        {
            await this.userManager.CreateAsync(new StoreUser 
            { 
                Email = "admin@admin.com",
                UserName = "admin",
                EmailConfirmed = true,
                PhoneNumber = "123123123"
            }, "123456");

            return this.Ok();
        }

        public async Task<IActionResult> LogInUser()
        {
            await this.signInManager.PasswordSignInAsync("admin","123456", true, false);

            return this.Ok();
        }

        public async Task<IActionResult> CreateRole()
        {
            await this.roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            var user =  await this.userManager.GetUserAsync(this.User);
            await this.userManager.AddToRoleAsync(user, "Admin");

            return this.Ok();
        }

    }
}
