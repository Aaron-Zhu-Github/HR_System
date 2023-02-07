using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRSystem.Models
{
    [Table("Address")]
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        [DisplayName("Address Line 1"), Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string AddressLine1 { get; set; }


        [DisplayName("Address Line 2")]
        [StringLength(200)]
        public string? AddressLine2 { get; set; }


        [StringLength(20)]
        public string City { get; set; }


        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }


        [DisplayName("State Name"), Required(ErrorMessage = "Name of the State is required")]
        [StringLength(50)]
        public string StateName { get; set; }


        [DisplayName("State Name Abbreviation")]
        [StringLength(5)]
        public string StateAbbr { get; set; }

        public int PersonId { get; set; }

        public bool isSecondary { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}
