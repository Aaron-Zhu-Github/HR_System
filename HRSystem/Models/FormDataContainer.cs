using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRSystem.Models
{

    public class FormDataContainer
    {
       public Person person { get; set; }
       public Employee employee { get; set; }
       public List<Contact> contactList { get; set; }

    }
}
