using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Planmember
    {
        public int PlanMemberId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DatePayed { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool? IsPayed { get; set; }
        public int AdministratorId { get; set; }
    }
}
