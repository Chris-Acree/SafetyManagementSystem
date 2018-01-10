using System;
using System.Collections.Generic;

namespace SafetyManagementSystem.Models
{
    public partial class HazardCategories
    {
        public HazardCategories()
        {
            HazardReports = new HashSet<HazardReports>();
        }

        public int HazardCategoryId { get; set; }
        public string HazardCategory { get; set; }

        public ICollection<HazardReports> HazardReports { get; set; }
    }
}
