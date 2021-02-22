using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services
{
    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<string> All();
    }
}
