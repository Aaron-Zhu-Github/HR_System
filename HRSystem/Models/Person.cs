namespace HRSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public int Id { get; set; }


        [Display(Name = "First Name"), Required(ErrorMessage = "First Name must be inserted")]
        public string? Firstname { get; set; }


        [Display(Name = "Last Name"), Required(ErrorMessage = "First Name must be inserted")]
        public string? Lastname { get; set; }


        [Display(Name = "Middle Name")]
        public string? Middlename { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Phone number must be inserted")]
        [DataType(DataType.PhoneNumber)]
        public string? CellPhone { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string? AlternatePhone { get; set; }


        //Gender
        public enum Gender
        {
            Male,
            Female,
            Other
        }


        [Required(ErrorMessage = "You must insert a SSN")]
        public string? SSN { get; set; }


        [Required(ErrorMessage = "You must insert your date of birth")]
        [DataType(DataType.Date)]
        public DateOnly DOB { get; set; }


    }
}
