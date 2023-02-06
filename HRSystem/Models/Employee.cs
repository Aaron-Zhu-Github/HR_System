using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Controllers.Models
{
    public class Employee
    {
        public int Id { get; set; }


        public int PersonId { get; set; }


        [Required]
        public string Title { get; set; }


        public int ManagerId { get; set; }


        [Required, DisplayName("Employment Start Date")]
        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }


        [Required, DisplayName("Employment End Date")]
        [DataType(DataType.Date)]
        public DateOnly EndDate { get; set;}


        //avatar


        //Optional to class
        [StringLength(50)]
        public string Car { get; set; }


        public int VisaStatusId { get; set; }


        [Required, DisplayName("Visa Start Date")]
        [DataType(DataType.Date)]
        public DateOnly VisaStartDate { get; set; }


        [Required, DisplayName("Visa End Date")]
        [DataType(DataType.Date)]
        public DateOnly VisaEndDate { get;set; }


        [Required, DisplayName("Driver's Lisence")]
        [StringLength(50)]
        public string DriverLisence { get; set; }


        [Required, DisplayName("Driver's Lisence Expiration Date")]
        [DataType(DataType.Date)]
        public DateOnly DriverLisence_ExpirationDate { get; set; }
        

        [Required]
        public int HouseId { get; set; }
    }
}
