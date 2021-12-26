using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomTemplateAPI.Models
{
    public class Student
    {
        public int StudentID { get; set; }=0;
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Address> Addresses { get; set; }

        public Student()
        {
            this.Addresses = new List<Address>();
        }
    }
}
