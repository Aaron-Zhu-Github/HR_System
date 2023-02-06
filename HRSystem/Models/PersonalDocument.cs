using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Controllers.Models
{
    public class PersonalDocument
    {
        public int Id { get; set; }


        public int EmployeeId { get; set; }


        [Required]
        [DataType(DataType.Url)]
        public string Path { get; set; }


        [StringLength(50)]
        public string Title { get; set; }


        [StringLength(500)]
        public string Comment { get; set; }


        [Required, DisplayName("Created Date")]
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }


        [Required, DisplayName("Created By")]
        public int CreatedBy { get; set; }
    }
}
