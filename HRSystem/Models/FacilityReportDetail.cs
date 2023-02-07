using System;
namespace HRSystem.Models
{
    public class FacilityReportDetail
    {
        public int ID { get; set; }
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModificationDate { get; set; }
    }
}