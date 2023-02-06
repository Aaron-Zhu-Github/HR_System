using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Controllers.Models
{
    public class VisaStatus
    {
        public int Id { get; set; }


        [Required, DisplayName("Visa Type")]
        public string VisaType { get; set; }


        [Required]
        public bool Active { get; set; }


        [Required, DisplayName("Modification Date")]
        [DataType(DataType.Date)]
        public DateOnly ModificationDate { get; set; }


        [Required, DisplayName("Create User")]
        public int CreateUser { get; set; }
    }
}
