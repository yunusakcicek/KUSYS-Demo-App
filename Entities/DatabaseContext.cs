using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(2000, 01, 01),
                    Email = "student@ku.edu.tr",
                    Password = "148506E98B3E74992CFF915C8CBD5591",//123456
                    StudentId = Guid.NewGuid()
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Alex",
                    LastName = "Terry",
                    BirthDate = new DateTime(2002, 01, 01),
                    Email = "10101234@ku.edu.tr",
                    Password = "148506E98B3E74992CFF915C8CBD5591",//123456
                    StudentId = Guid.NewGuid()
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "test1",
                    LastName = "test11",
                    BirthDate = new DateTime(2002, 01, 01),
                    Email = "test1test1@ku.edu.tr",
                    Password = "148506E98B3E74992CFF915C8CBD5591",//123456
                    StudentId = Guid.NewGuid()
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "test2",
                    LastName = "test22",
                    BirthDate = new DateTime(2002, 01, 01),
                    Email = "test2test2@ku.edu.tr",
                    Password = "148506E98B3E74992CFF915C8CBD5591",//123456
                    StudentId = Guid.NewGuid()
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "test3",
                    LastName = "test33",
                    BirthDate = new DateTime(2002, 01, 01),
                    Email = "test3test3@ku.edu.tr",
                    Password = "148506E98B3E74992CFF915C8CBD5591",//123456
                    StudentId = Guid.NewGuid()
                },
                new User
                {
                    UserId = Guid.NewGuid(),
                    FirstName = "Allen",
                    LastName = "Denswill",
                    BirthDate = new DateTime(1980, 01, 01),
                    Email = "admin@ku.edu.tr",
                    Password = "148506E98B3E74992CFF915C8CBD5591",//123456
                    UserRole = "Admin"
                }); ;
            modelBuilder.Entity<Course>()
                .HasData(new Course
                {
                    CourseId = Guid.NewGuid(),
                    CourseRefId = "CSI101",
                    CourseName = "Introduction to Computer Science"
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    CourseRefId = "CSI102",
                    CourseName = "Algorithms"
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    CourseRefId = "MAT101",
                    CourseName = "Calculus"
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    CourseRefId = "PHY101",
                    CourseName = "Physics"
                });
        }


        public DbSet<User> UserData { get; set; }
        public DbSet<Course> CourseData { get; set; }
        public DbSet<CourseStudent> CourseStudentData { get; set; }
    }
}

