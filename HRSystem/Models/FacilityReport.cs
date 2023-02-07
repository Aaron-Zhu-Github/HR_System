using System;
namespace HRSystem.Models
{
    public class FacilityReport
    {
        public int ID { get; set; }
        //public int ContactID { get; set; }
        //public string TYPE { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EmployeeID { get; set; }
        //public int Quantity { get; set; }
        public DateTime ReportDate { get; set; }
        //public int HouseID { get; set; }
        public string STATUS { get; set; }
    }
}