﻿using System.Collections.Generic;

namespace AnimalBalanceApp.Core.Entities
{
    public partial class Species
    {
        public Species()
        {
            Animals = new HashSet<Animal>();
        }

        public int SpecieId { get; set; }
        public string TypeSpecie { get; set; }
        public string Temperature { get; set; }
        public string SpaceForUnity { get; set; }
        public string WaterForDay { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
