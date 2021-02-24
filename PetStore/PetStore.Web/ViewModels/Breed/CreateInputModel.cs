﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Breed
{
    public class CreateInputModel
    {
        [Required()]
        [MinLength(3, ErrorMessage = "Name should be more than 3 symbols!")]
        public string Name { get; set; }
    }
}