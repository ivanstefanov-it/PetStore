namespace PetStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;

    public class StoreUser : IdentityUser
    {
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}