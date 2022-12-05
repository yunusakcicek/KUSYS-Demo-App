using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUSYS_Demo.Entities
{
    [Table("UserData")]
	public class User
	{
		public User()
		{
		}
		[Key]
		public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
		[StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string UserRole { get; set; } = "Student";
        public bool Locked { get; set; } = false;
		public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

	}
}

