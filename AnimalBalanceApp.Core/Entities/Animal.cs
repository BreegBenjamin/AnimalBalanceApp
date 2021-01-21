using System.Collections.Generic;

namespace AnimalBalanceApp.Core.Entities
{
    public partial class Animal : BaseEntity
    {
        public Animal()
        {
            Products = new HashSet<Product>();
        }

        public int SpecieId { get; set; }
        public string AnimalName { get; set; }
        public string Price { get; set; }
        public string AgeForSale { get; set; }

        public virtual Species Specie { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
