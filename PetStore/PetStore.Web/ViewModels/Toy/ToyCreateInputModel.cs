using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Toy
{
    public class ToyCreateInputModel
    {

        [Required()]
        [MinLength(3, ErrorMessage = "{0} should be more than {1} symbols!")]
        public string Name { get; set; }

        [Required()]
        [MinLength(10, ErrorMessage = "{0} should be more than {1} symbols!")]
        public string Description { get; set; }

        [Range(0, 10000)]
        public decimal DistributorPrice { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
