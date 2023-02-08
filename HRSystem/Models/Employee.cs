using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        public int PersonId { get; set; }
        //EF relationship
        public virtual Person? Person { get; set; }


        public string? Title { get; set; }


        public int ManagerId { get; set; }


        [DisplayName("Employment Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }


        [DisplayName("Employment End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }


        //avatar


        [StringLength(50)]
        public string? Car { get; set; }


        public int VisaStatusId { get; set; }
        //EF relationship
        public virtual VisaStatus? VisaStatus { get; set;}


        [DisplayName("Visa Start Date")]
        [DataType(DataType.Date)]
        public DateTime? VisaStartDate { get; set; }


        [DisplayName("Visa End Date")]
        [DataType(DataType.Date)]
        public DateTime? VisaEndDate { get; set; }


        [DisplayName("Driver's Lisence")]
        [StringLength(50)]
        public string DriverLisence { get; set; }


        [DisplayName("Driver's Lisence Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? DriverLisence_ExpirationDate { get; set; }


        public int HouseId { get; set; }


        //EF realtionship
        public virtual ApplicationWorkFlow? ApplicationWorkFlow { get; set; }

        public virtual ICollection<PersonalDocument>? PersonalDocuments { get; set; }
    }
}
