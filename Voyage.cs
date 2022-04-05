using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Voyage
    {
        public int VoyageShipId { get; set; }
        public string? VoyageDate { get; set; }
        public int VoyageDeparturePort { get; set; }
        public DateTime VoyageStart { get; set; }
        public int VoyageArrivalPort { get; set; }
        public DateTime VoyageEnd { get; set; }

        public virtual Port VoyageArrivalPortNavigation { get; set; } = null!;
        public virtual Port VoyageDeparturePortNavigation { get; set; } = null!;
        public virtual Ship VoyageShip { get; set; } = null!;
    }
}
