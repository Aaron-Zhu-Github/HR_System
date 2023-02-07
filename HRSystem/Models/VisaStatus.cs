using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("VisaStatus")]
    public class VisaStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        [DisplayName("Visa Type")]
        public string VisaType { get; set; }


        public bool Active { get; set; }


        //[Required, DisplayName("Modification Date")]
        [DataType(DataType.Date)]
        public DateTime ModificationDate { get; set; }


        [DisplayName("Create User")]
        public int CreateUser { get; set; }


        //EF relationship
        public virtual Employee Employee { get; set; }
    }
}
