using System;
using System.Collections.Generic;

namespace SafetyManagementSystem.Models
{
    public partial class Sites
    {
        public Sites()
        {
            HazardReports = new HashSet<HazardReports>();
            Incidents = new HashSet<Incidents>();
        }

        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SafetyRepName { get; set; }
        public string SafetyRepEmail { get; set; }

        public ICollection<HazardReports> HazardReports { get; set; }
        public ICollection<Incidents> Incidents { get; set; }
    }
}
