
namespace AnimalBalanceApp.Core.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int AnimalId { get; set; }
        public string ProductName { get; set; }
        public string PriceKm { get; set; }
        public string ImageName { get; set; }
        public string ContainerName { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
