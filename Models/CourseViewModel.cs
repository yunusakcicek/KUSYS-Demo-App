using KUSYS_Demo.Entities;
using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models
{
    public class CourseViewModel
    {
        public CourseViewModel()
        {
            this.CourseList = new List<Course>();
        }
        [Required(ErrorMessage = "Course name is required.")]
        [MinLength(5, ErrorMessage = "Course name must be min 5 characters.")]
        [MaxLength(45, ErrorMessage = "Course name must be max 45 characters.")]
        public string CourseName { get; set; }
        public string? CourseRefId { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
