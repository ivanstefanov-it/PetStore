using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Food
{
    public class FoodCreateInputModel
    {
        [Required()]
        [MinLength(3, ErrorMessage = "Name should be more than {1} symbols!")]
        public string Name { get; set; }

        // In KG.
        [Range(0, 200)]
        public double Weight { get; set; }

        [Range(0, 10000)]
        public decimal DistributorPrice { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }
    }
}
