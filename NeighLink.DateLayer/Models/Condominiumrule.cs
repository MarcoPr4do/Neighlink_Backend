using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Condominiumrule
    {
        public int CondominiumRuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CondominiumId { get; set; }
    }
}
