using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Country
    {
      
        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<Port> ?Ports { get; set; }
    }
}
