using KUSYS_Demo.Entities;
using KUSYS_Demo.Models;

namespace KUSYS_Demo.Services
{
    public class OperationsService : BaseService
    {
        private readonly CoreServices _coreServices;
        public OperationsService(DatabaseContext databaseContext, IConfiguration configuration) : base(databaseContext, configuration)
        {
            _coreServices = new CoreServices(databaseContext, configuration);
        }

        #region Student Ops.
        public UserViewModel GetStudentList(UserViewModel userViewModel)
        {
            try
            {
                //Available course list from db
                var studentList_ = _databaseContext.UserData.Where(x => x.Locked == false && x.UserRole.ToLower().Contains("student")).ToList();
                userViewModel.StudentList = studentList_;
                return userViewModel;
            }
            catch (Exception ex)
            {
                return new UserViewModel();
            }
        }
        public bool CreateStudent(UserViewModel userViewModel)
        {
            try
            {
                if (userViewModel != null)
                {
                    //Checking if there is student with the same email address
                    var duplicateData_ = _databaseContext.UserData.Where(x => x.Email.ToLower().Equals(userViewModel.Email.ToLower()));
                    if (!duplicateData_.Any())
                    {
                        //Random r = new Random();
                        //int randNum = r.Next(1000000);
                        //string sixDigitNumber = randNum.ToString("D6");
                        var userDataModel_ = new User();
                        userDataModel_.UserId = Guid.NewGuid();
                        userDataModel_.StudentId = Guid.NewGuid();
                        userDataModel_.Email = userViewModel.Email+"@ku.edu.tr";
                        userDataModel_.FirstName = userViewModel.FirstName;
                        userDataModel_.LastName = userViewModel.LastName;
                        userDataModel_.BirthDate = userViewModel.BirthDate;
                        userDataModel_.Password = _coreServices.EncryptPassword(userViewModel.BirthDate.ToString("ddMMyyyy") + userViewModel.LastName.ToLower());//04041996denswill
                        userDataModel_.CreateDateTime = DateTime.Now;
                        userDataModel_.ModifiedDateTime = DateTime.Now;
                        _databaseContext.UserData.Add(userDataModel_);
                        int effectedRows_ = _databaseContext.SaveChanges();
                        if (effectedRows_ > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error log here
                return false;
            }
        }
        public bool DeleteStudent(string userId)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    //Checking if there is student with the same email address
                    var userData_ = _databaseContext.UserData.Where(x => x.UserId.ToString().Equals(userId)).FirstOrDefault();
                    if (userData_ != null)
                    {
                        var courseStudentDataList_ = _databaseContext.CourseStudentData.Where(x => x.UserId.ToString().Equals(userId)).ToList();
                        if(courseStudentDataList_.Count > 0)
                        {
                            //Student deleted from courses.
                            _databaseContext.CourseStudentData.RemoveRange(courseStudentDataList_);
                            _databaseContext.SaveChanges();
                        }
                        userData_.Locked = true;
                        userData_.ModifiedDateTime = DateTime.Now;
                        int effectedRows_ = _databaseContext.SaveChanges();
                        if (effectedRows_ > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error log here
                return false;
            }
        }
        public bool EditStudent(string userId, UserViewModel userViewModel)
        {
            try
            {
                var userData_ = _databaseContext.UserData.Where(x => x.UserId.ToString().Equals(userId) && x.Locked == false).FirstOrDefault();
                if (userData_ != null)
                {
                    userData_.Email = userViewModel.Email+"@ku.edu.tr";
                    userData_.FirstName = userViewModel.FirstName;
                    userData_.LastName = userViewModel.LastName;
                    userData_.BirthDate = userViewModel.BirthDate;
                    userData_.ModifiedDateTime = DateTime.Now;
                    int effectedRows_ = _databaseContext.SaveChanges();
                    if (effectedRows_ > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error log here
                return false;
            }
        }
        public bool AssignCoursesToStudent(string userId, string[] courseIdList)
        {
            try
            {
                if (!string.IsNullOrEmpty(userId) && courseIdList.Length > 0)
                {
                    foreach (var courseId in courseIdList)
                    {
                        var courseStudentData_ = new CourseStudent();
                        courseStudentData_.CourseUserId = Guid.NewGuid();
                        courseStudentData_.CourseId = new Guid(courseId);
                        courseStudentData_.UserId = new Guid(userId);
                        _databaseContext.CourseStudentData.Add(courseStudentData_);
                    }
                    int effectedRows_ = _databaseContext.SaveChanges();
                    if (effectedRows_ > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Course Ops.
        public CourseViewModel GetCourseList(CourseViewModel courseViewModel)
        {
            try
            {
                //Available course list from db
                var courseList_ = _databaseContext.CourseData.Where(x => x.Locked == false).ToList();
                courseViewModel.CourseList = courseList_;
                return courseViewModel;
            }
            catch (Exception ex)
            {
                return new CourseViewModel();
            }
        }

        public bool CreateCourse(CourseViewModel courseViewModel)
        {
            try
            {
                if (courseViewModel != null)
                {
                    //Checking if there is course with the same name
                    var duplicateData_ = _databaseContext.CourseData.Where(x => x.CourseName.ToLower().Equals(courseViewModel.CourseName.ToLower()) && x.Locked == false);
                    if (!duplicateData_.Any())
                    {
                        var courseDataModel_ = new Course();
                        courseDataModel_.CourseId = Guid.NewGuid();
                        courseDataModel_.CourseRefId = courseViewModel.CourseName.Substring(0,4)+ (new Random()).Next(100, 1000).ToString();
                        courseDataModel_.CourseName = courseViewModel.CourseName;
                        courseDataModel_.CreateDateTime = DateTime.Now;
                        _databaseContext.CourseData.Add(courseDataModel_);
                        int effectedRows_ = _databaseContext.SaveChanges();
                        if (effectedRows_ > 0)
                        {
                            return true;
                        }
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                //Error Log here
                return false;
            }
        }
        public bool DeleteCourse(string courseId)
        {
            try
            {
                if (!string.IsNullOrEmpty(courseId))
                {
                    //Checking if there is student with the same email address
                    var courseData_ = _databaseContext.CourseData.Where(x => x.CourseId.ToString().Equals(courseId)).FirstOrDefault();
                    if (courseData_ != null)
                    {
                        if (!_databaseContext.CourseStudentData.Where(x => x.CourseId.ToString().Equals(courseId)).Any())
                        {
                            courseData_.Locked = true;
                            courseData_.ModifiedDateTime = DateTime.Now;
                            int effectedRows_ = _databaseContext.SaveChanges();
                            if (effectedRows_ > 0)
                            {
                                return true;
                            }
                        }

                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error log here
                return false;
            }
        }
        public bool EditCourse(string courseId, string courseName)
        {
            try
            {
                var courseData_ = _databaseContext.CourseData.Where(x => x.CourseId.ToString().Equals(courseId) && x.Locked == false).FirstOrDefault();
                if (courseData_ != null)
                {
                    courseData_.CourseName = courseName;
                    courseData_.ModifiedDateTime = DateTime.Now;
                    int effectedRows_ = _databaseContext.SaveChanges();
                    if (effectedRows_ > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //Error log here
                return false;
            }
        }

        public List<User> GetListOfStudentsForCourse(string courseId)
        {
            try
            {
                //Students which not taking this course
                var studentsForCourse_ = _databaseContext.CourseStudentData.Where(x => x.CourseId.ToString().Equals(courseId)).Select(x=>x.UserId).ToList();
                var studentList_ = _databaseContext.UserData.Where(x => x.Locked == false && x.UserRole.ToLower().Contains("student") && !studentsForCourse_.Contains(x.UserId)).ToList();

                return studentList_;
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }
        public List<Course> GetListOfCoursesForStudent(string userId)
        {
            try
            {
                //Students which not taking this course
                var coursesForStudent_ = _databaseContext.CourseStudentData.Where(x => x.UserId.ToString().Equals(userId)).Select(x => x.CourseId).ToList();
                var courseList_ = _databaseContext.CourseData.Where(x => x.Locked == false && !coursesForStudent_.Contains(x.CourseId)).ToList();
                return courseList_;
            }
            catch (Exception ex)
            {
                return new List<Course>();
            }
        }
        public bool AssignStudentsToCourse(string courseId, string[] studentUserIdList)
        {
            try
            {
                if(!string.IsNullOrEmpty(courseId) && studentUserIdList.Length > 0)
                {
                    foreach (var studentUserId in studentUserIdList)
                    {
                        var courseStudentData_ = new CourseStudent();
                        courseStudentData_.CourseUserId = Guid.NewGuid();
                        courseStudentData_.CourseId = new Guid(courseId);
                        courseStudentData_.UserId = new Guid(studentUserId);
                        _databaseContext.CourseStudentData.Add(courseStudentData_);
                    }
                    int effectedRows_ = _databaseContext.SaveChanges();
                    if (effectedRows_ > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region CourseStudent Ops.
        public List<CourseStudentViewModel> GetCourseStudentList()
        {
            try
            {
                //Getting course-student list from db
                var studentCourseList_ = _databaseContext.CourseStudentData.ToList();
                var studentCourseViewList_ = new List<CourseStudentViewModel>();
                foreach (var studentCourseItem in studentCourseList_)
                {
                    studentCourseViewList_.Add(new CourseStudentViewModel
                    {
                        CourseViewModel = _databaseContext.CourseData.Where(x => x.Locked == false && x.CourseId.Equals(studentCourseItem.CourseId)).FirstOrDefault(),
                        UserViewModel = _databaseContext.UserData.Where(x => x.Locked == false && x.UserId.Equals(studentCourseItem.UserId)).FirstOrDefault()
                    });
                }
                return studentCourseViewList_;
            }
            catch (Exception ex)
            {
                return new List<CourseStudentViewModel>();
            }
        }
        #endregion
    }
}
