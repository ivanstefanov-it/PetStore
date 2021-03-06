﻿using PetStore.Services.Models.Breed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Web.ViewModels.Breed
{
    public class AllBreedViewModel
    {
        public IEnumerable<BreedListingServiceModel> Breeds { get; set; }

        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage - 1;

        public int NextPage => this.CurrentPage + 1;

        public bool PreviousDisabled => this.CurrentPage == 1;

        public bool NextDisabled
        {
            get
            {
                var maxPage = Math.Ceiling(((double)this.Total) / 9);

                return maxPage == CurrentPage;
            }
        }
    }
}
