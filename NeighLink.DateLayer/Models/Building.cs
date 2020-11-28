using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public int? NumberOfHomes { get; set; }
        public bool? IsDelete { get; set; }
        public int CondominiumId { get; set; }
    }
}
