using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Controllers.Models
{
    public class ApplicationWorkFlow
    {
        public int Id { get; set; }


        public int EmployeeId { get; set; }


        [Required, DisplayName("Created Date")]
        [DataType(DataType.Date)]
        public DateOnly CreatedDate { get; set; }


        [Required, DisplayName("Modification Date")]
        [DataType(DataType.Date)]
        public DateOnly ModificationDate { get; set; }


        [Required, DisplayName("Application Status")]
        public bool Status { get; set; }


        [StringLength(500, ErrorMessage = "Please write down less than 500 letters")]
        public string Comments { get; set; }


        [Required, DisplayName("Application Type")]
        [StringLength(20)]
        public string Type { get; set; }
    }
}
