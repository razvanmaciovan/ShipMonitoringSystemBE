using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Port
    {
        public int PortId { get; set; }
        public string PortName { get; set; } = null!;
        public int? PortCountryId { get; set; }

        public virtual Country? PortCountry { get; set; }
    }
}
