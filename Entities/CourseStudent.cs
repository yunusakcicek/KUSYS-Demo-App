using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUSYS_Demo.Entities
{
    [Table("CourseStudentData")]
    public class CourseStudent
	{
		public CourseStudent()
		{
		}
        [Key]
        public Guid CourseUserId { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid UserId { get; set; }


    }
}

