using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUSYS_Demo.Entities
{
    [Table("CourseData")]
    public class Course
	{
		public Course()
		{
		}
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }
        public string CourseRefId { get; set; }
        public bool Locked { get; set; } = false;
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime ModifiedDateTime { get; set; } = DateTime.Now;
    }
}

