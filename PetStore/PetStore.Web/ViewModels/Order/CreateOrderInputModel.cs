using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Order
{
    public class CreateOrderInputModel
    {
        //трябва ни типа който да листнем. животно или храна и да покажем пропутрите на view-то. Нещо като comfirmDelete 
        public int ShowModel { get; set; }

        public DateTime PurchaseDate { get; set; }

    }
}
