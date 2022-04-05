using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Ship
    {
        public int ShipId { get; set; }
        public string ShipName { get; set; } = null!;
        public float? ShipSpeedMax { get; set; }
    }
}
