using PetStore.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        int Create(CategoryCreateServiceModel model);
    }
}
