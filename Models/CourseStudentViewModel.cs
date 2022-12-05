using System;
using KUSYS_Demo.Entities;

namespace KUSYS_Demo.Models
{
	public class CourseStudentViewModel
	{
		public CourseStudentViewModel()
		{

		}
		public Course CourseViewModel { get; set; }
		public User UserViewModel { get; set; }
	}
}

