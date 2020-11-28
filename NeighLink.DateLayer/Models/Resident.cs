using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Resident
    {
        public int ResidentId { get; set; }
        public bool? IsBlocked { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
