using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Administrator
    {
        public int AdministratorId { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? PlanActivated { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
