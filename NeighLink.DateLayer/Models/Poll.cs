using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Poll
    {
        public int PollId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? AdministratorId { get; set; }
        public bool? IsDelete { get; set; }
        public int CondominiumId { get; set; }
    }
}
