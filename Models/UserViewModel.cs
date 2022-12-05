using System.ComponentModel.DataAnnotations;
using KUSYS_Demo.Entities;

namespace KUSYS_Demo.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.StudentList = new List<User>();
        }
        [Required(ErrorMessage ="Email is required.")]
        [MinLength(10,ErrorMessage ="Email must be min 10 characters.")]
        [MaxLength(35, ErrorMessage = "Email must be max 35 characters.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Firstname is required.")]
        [MinLength(3, ErrorMessage = "Firstname must be min 3 characters.")]
        [MaxLength(25, ErrorMessage = "Firstname must be max 25 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required.")]
        [MinLength(3, ErrorMessage = "Lastname must be min 3 characters.")]
        [MaxLength(25, ErrorMessage = "Lastname must be max 25 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birthdate is required.")]
        public DateTime BirthDate { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string? UserId { get; set; }
        public List<User> StudentList { get; set; }
    }
}
