using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Condominium
    {
        public int CondominiumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool? IsDelete { get; set; }
        public int AdministratorId { get; set; }
    }
}
