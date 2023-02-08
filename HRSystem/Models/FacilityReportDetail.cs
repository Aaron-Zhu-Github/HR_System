using System;
namespace HRSystem.Models
{
    public class FacilityReportDetail
    {
        public int ID { get; set; }
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        // EF Relationships
        public virtual FacilityReport? FacilityReport { get; set; }
    }
}