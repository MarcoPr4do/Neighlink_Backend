using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int CondominiumId { get; set; }
    }
}
