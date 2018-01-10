using System;
using System.Collections.Generic;

namespace SafetyManagementSystem.Models
{
    public partial class Incidents
    {
        public int IncidentId { get; set; }
        public int SiteId { get; set; }
        public bool? IsReportable { get; set; }
        public bool? InjuriesOccured { get; set; }
        public bool? RequiredFirstAid { get; set; }
        public string EmployeeFname { get; set; }
        public string EmployeeLname { get; set; }
        public string EmployeeEmail { get; set; }
        public string EventLocation { get; set; }
        public string InjuryDescription { get; set; }
        public string PreventativeActions { get; set; }
        public DateTime DateEntered { get; set; }

        public Sites Site { get; set; }
    }
}
