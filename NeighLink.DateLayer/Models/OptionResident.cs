using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class OptionResident
    {
        public int OptionResidentId { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }
        public bool? IsDelete { get; set; }
        public int OptionId { get; set; }
        public int ResidentId { get; set; }
        public int ResidentUserId { get; set; }
    }
}
