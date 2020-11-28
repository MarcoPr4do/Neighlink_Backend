using System;
using System.Collections.Generic;

namespace NeighLink.DateLayer.Models
{
    public partial class ResidentDepartment
    {
        public int ResidentDepartmentId { get; set; }
        public int? CondiminiumId { get; set; }
        public int? BuildingId { get; set; }
        public bool? IsDelete { get; set; }
        public int ResidentId { get; set; }
        public int DepartmentId { get; set; }
    }
}
