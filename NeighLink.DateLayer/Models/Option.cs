using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class Option
    {
        public int OptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PollId { get; set; }
        public bool? IsDelete { get; set; }
    }
}
