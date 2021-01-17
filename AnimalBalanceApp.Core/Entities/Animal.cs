using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalBalanceApp.Core.Entitis
{
    public partial class Animal
    {
        public Animal()
        {
            Products = new HashSet<Product>();
        }

        public int AnimalId { get; set; }
        public int SpecieId { get; set; }
        public string AnimalName { get; set; }
        public string Price { get; set; }
        public string AgeForSale { get; set; }

        public virtual Species Specie { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
