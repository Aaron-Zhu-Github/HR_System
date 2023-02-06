namespace HRSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        public int Id { get; set; }



        public int PersonId { get; set; }


        [StringLength(20)]
        public string? Relationship { get; set; }


        [StringLength(20)]
        public string? Title { get; set; }


        [Required]
        public bool isReferrence { get; set; }


        [Required]
        public bool isEmergency { get; set; }


        [Required]
        public bool isLandload { get; set; }
    }
}
