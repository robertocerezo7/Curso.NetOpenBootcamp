using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Student:BaseEntity
    {
        [Required]
        public String FirstName { get; set; } = string.Empty;

        [Required]
        public String LastName { get; set; } = string.Empty;

        [Required]
        public DateTime Dob {  get; set; }

        public ICollection<Course> Courses {  get; set; } = new List<Course>();


    }
}
