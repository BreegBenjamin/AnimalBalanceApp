using System;

namespace AnimalBalanceApp.Core.Entities
{
    public partial class Image
    {
        public int ImageNum { get; set; }
        public int PostId { get; set; }
        public string ContainerImageName { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public DateTime PostDate { get; set; }

        public virtual Post Post { get; set; }
    }
}
