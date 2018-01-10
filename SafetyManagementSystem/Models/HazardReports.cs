using System;
using System.Collections.Generic;

namespace SafetyManagementSystem.Models
{
    public partial class HazardReports
    {
        public int HazardReportId { get; set; }
        public int SiteId { get; set; }
        public string ReportedByEmployee { get; set; }
        public string ReportedByEmpDept { get; set; }
        public int? HazardCategoryId { get; set; }
        public string Witnesses { get; set; }
        public string AffectedPersonnel { get; set; }
        public string HazardLocation { get; set; }
        public string InvolvedMaterial { get; set; }
        public string Issue { get; set; }
        public string HazardPotential { get; set; }
        public DateTime? HazardReportDate { get; set; }
        public string RegulatoryViolation { get; set; }
        public string Supervisor { get; set; }
        public string Manager { get; set; }
        public string SuggestedCorrections { get; set; }
        public string CorrectiveAction { get; set; }
        public bool? RequiredPurchases { get; set; }
        public decimal? CostOfPurchases { get; set; }
        public DateTime? DateImplemented { get; set; }
        public string AdminEmployee { get; set; }
        public DateTime? AdminDate { get; set; }

        public HazardCategories HazardCategory { get; set; }
        public Sites Site { get; set; }
    }
}
