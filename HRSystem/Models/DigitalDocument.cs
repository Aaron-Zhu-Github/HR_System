using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Controllers
{
    public class DigitalDocument
    {
        public int Id { get; set; }


        [DisplayName("Type of the document")]
        public string Type { get; set; }


        public bool Required { get; set; }


        [DataType(DataType.Url)]
        public string TemplateLocation { get; set; }


        [StringLength(500)]
        public string Description { get; set; }
    }
}
