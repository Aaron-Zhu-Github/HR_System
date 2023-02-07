using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("Contact")]
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        public int PersonId { get; set; }


        [StringLength(20)]
        public string? Relationship { get; set; }


        [StringLength(20)]
        public string? Title { get; set; }


        public bool isReferrence { get; set; }


        public bool isEmergency { get; set; }


        public bool isLandload { get; set; }


    }
}

