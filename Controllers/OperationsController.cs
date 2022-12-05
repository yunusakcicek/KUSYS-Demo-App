using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUSYS_Demo.Entities;
using KUSYS_Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUSYS_Demo.Controllers
{
    [Authorize]
    public class OperationsController : Controller
    {
        private readonly Services.OperationsService OperationsService_;
        public OperationsController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            OperationsService_ = new Services.OperationsService(databaseContext, configuration);
        }
        // GET: /<controller>/
        public IActionResult StudentOperations(UserViewModel userViewModel)
        {
            try
            {
                var userViewModel_ = OperationsService_.GetStudentList(userViewModel);
                return View(userViewModel_);
            }
            catch (Exception ex)
            {
                return View(new UserViewModel());
            }
        }
        [HttpPost]
        public IActionResult CreateStudent(UserViewModel userViewModel)
        {
            try
            {
                ModelState.Remove("UserId");
                if (ModelState.IsValid)
                {
                    bool isAdded_ = OperationsService_.CreateStudent(userViewModel);
                    if (isAdded_)
                    {
                        return Ok("Student created.");
                    }

                }
                return BadRequest("Invalid values. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return BadRequest("Error: " + ex.Message);
                throw;
            }
        }
        [HttpPost]
        public IActionResult DeleteStudent(string UserId)
        {
            try
            {
                bool isDeleted_ = OperationsService_.DeleteStudent(UserId);
                if (isDeleted_)
                {
                    return Ok("Student info deleted.");
                }
                return BadRequest("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return BadRequest("Error: " + ex.Message);
                throw;
            }

        }
        [HttpPost]
        public IActionResult EditStudent(UserViewModel StudentModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(StudentModel.UserId) && StudentModel != null)
                {
                    bool isEdited_ = OperationsService_.EditStudent(StudentModel.UserId, StudentModel);
                    if (isEdited_)
                    {
                        return Ok("Student edited.");
                    }

                }
                return BadRequest("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return BadRequest("Error: " + ex.Message);
                throw;
            }

        }
        public string AssignCoursesToStudent(string UserId, string[] CourseIdList)
        {
            try
            {
                bool isCompleted_ = OperationsService_.AssignCoursesToStudent(UserId, CourseIdList);
                if (isCompleted_)
                {
                    return "Student assigned to Courses.";
                }
                return "Error. Please contact system admin.";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }
        public string GetCoursesForStudent(string UserId)
        {
            try
            {
                var ListOfCourses_ = OperationsService_.GetListOfCoursesForStudent(UserId);
                var htmlData_ = new StringBuilder();
                foreach (var course in ListOfCourses_)
                {
                    htmlData_.Append(@"<option value=" + course.CourseId + ">" + course.CourseName + "</option>");
                }
                return htmlData_.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public IActionResult CourseOperations(CourseViewModel courseViewModel)
        {
            try
            {
                var courseViewModel_ = OperationsService_.GetCourseList(courseViewModel);
                return View(courseViewModel_);
            }
            catch (Exception ex)
            {
                return View(new CourseViewModel());
            }
        }
        public IActionResult CreateCourse(CourseViewModel courseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isAdded_ = OperationsService_.CreateCourse(courseViewModel);
                    if (isAdded_)
                    {
                        return Ok("Course added.");
                    }
                    
                }
                return BadRequest("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return BadRequest("Error: "+ex.Message);
                throw;
            }

        }
        public IActionResult EditCourse(string CourseId,string CourseName)
        {
            try
            {
                if (!string.IsNullOrEmpty(CourseId) && !string.IsNullOrEmpty(CourseName))
                {
                    bool isEdited_ = OperationsService_.EditCourse(CourseId, CourseName);
                    if (isEdited_)
                    {
                        return Ok("Course edited.");
                    }

                }
                return BadRequest("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return BadRequest("Error: " + ex.Message);
                throw;
            }

        }
        public IActionResult DeleteCourse(string CourseId)
        {
            try
            {
                bool isDeleted_ = OperationsService_.DeleteCourse(CourseId);
                if (isDeleted_)
                {
                    return Ok("Course deleted.");
                }
                return BadRequest("Theres students which assigned to this course or unable to delete.");
            }
            catch (Exception ex)
            {
                //Error log here
                return BadRequest("Error: " + ex.Message);
                throw;
            }

        }

        public PartialViewResult GetCourseList()
        {
            try
            {
                var courseViewModel_ = OperationsService_.GetCourseList(new CourseViewModel());
                if (courseViewModel_ != null)
                {
                    return PartialView("_CourseListPartial",courseViewModel_);
                }
                return PartialView("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return PartialView("Error: " + ex.Message);
                throw;
            }

        }
        public string GetStudentsForCourse(string CourseId)
        {
            try
            {
                var ListOfStudents_ = OperationsService_.GetListOfStudentsForCourse(CourseId);
                var htmlData_ = new StringBuilder();
                if (User.HasClaim("Roles", "Student"))
                {
                    ListOfStudents_ = ListOfStudents_.Where(x => x.UserId.ToString().Equals(User.FindFirst("UserId").Value)).ToList();
                }
                foreach (var student in ListOfStudents_)
                {
                    htmlData_.Append(@"<option value=" + student.UserId + ">" + student.Email+"("+student.FirstName +" "+student.LastName+")" + "</option>");
                }
                return htmlData_.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public string AssignStudentsToCourse(string CourseId, string[] StudentUserIdList)
        {
            try
            {
                bool isCompleted_ = OperationsService_.AssignStudentsToCourse(CourseId, StudentUserIdList);
                if (isCompleted_)
                {
                    return "Students added to course.";
                }
                return "Error. Please contact system admin.";
            }
            catch (Exception ex)
            {
                return "Error : "+ex.Message;
            }
        }

        public PartialViewResult GetStudentList()
        {
            try
            {
                var userViewModel_ = OperationsService_.GetStudentList(new UserViewModel());
                if (userViewModel_ != null)
                {
                    return PartialView("_StudentListPartial", userViewModel_);
                }
                return PartialView("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return PartialView("Error: " + ex.Message);
                throw;
            }

        }

        public PartialViewResult GetCourseStudentListPartialView()
        {
            try
            {
                var courseStudentViewModel_ = OperationsService_.GetCourseStudentList();
                if (courseStudentViewModel_ != null)
                {
                    return PartialView("_CourseStudentListPartial", courseStudentViewModel_);
                }
                return PartialView("Error occured. Try again.");
            }
            catch (Exception ex)
            {
                //Error log here
                return PartialView("Error: " + ex.Message);
                throw;
            }

        }
    }
}

