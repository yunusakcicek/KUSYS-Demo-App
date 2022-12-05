using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS_Demo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseData",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseRefId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Locked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseData", x => x.CourseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseStudentData",
                columns: table => new
                {
                    CourseUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentData", x => x.CourseUserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserRole = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Locked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CourseData",
                columns: new[] { "CourseId", "CourseName", "CourseRefId", "CreateDateTime", "Locked", "ModifiedDateTime" },
                values: new object[,]
                {
                    { new Guid("0f575ca0-5501-43a3-b60d-3bcf92d590b6"), "Introduction to Computer Science", "CSI101", new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1890), false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1890) },
                    { new Guid("2640bbb8-641a-4773-b827-4a525316867d"), "Physics", "PHY101", new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1930), false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1930) },
                    { new Guid("28a0a058-5da4-4db9-9423-bae56c52da99"), "Calculus", "MAT101", new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1920), false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1920) },
                    { new Guid("c99f763b-9522-4099-a3da-b4d878b85055"), "Algorithms", "CSI102", new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1910), false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1920) }
                });

            migrationBuilder.InsertData(
                table: "UserData",
                columns: new[] { "UserId", "BirthDate", "CreateDateTime", "Email", "FirstName", "LastName", "Locked", "ModifiedDateTime", "Password", "StudentId", "UserRole" },
                values: new object[,]
                {
                    { new Guid("01a66959-d107-4bc7-b300-608c49aaa97f"), new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1780), "test2test2@ku.edu.tr", "test2", "test22", false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1780), "148506E98B3E74992CFF915C8CBD5591", new Guid("b7e8492c-ba59-49d4-b557-5d2311742fcd"), "Student" },
                    { new Guid("6cf6b67a-5f67-43fd-874e-1b2a0c70ed11"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1810), "admin@ku.edu.tr", "Allen", "Denswill", false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1810), "148506E98B3E74992CFF915C8CBD5591", new Guid("00000000-0000-0000-0000-000000000000"), "Admin" },
                    { new Guid("75e79228-5a13-4ad3-a107-f08fbe6575e5"), new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1770), "test1test1@ku.edu.tr", "test1", "test11", false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1770), "148506E98B3E74992CFF915C8CBD5591", new Guid("32898aef-d627-4c2a-8d57-a2dc0e722aa2"), "Student" },
                    { new Guid("d7b08ad4-7f42-4ea8-9a1e-515a902e11e2"), new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1750), "10101234@ku.edu.tr", "Alex", "Terry", false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1750), "148506E98B3E74992CFF915C8CBD5591", new Guid("578af524-ff19-41e9-85a3-91439c2c502d"), "Student" },
                    { new Guid("e252c16d-e71f-416c-8232-06bf4c466a26"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1640), "student@ku.edu.tr", "John", "Doe", false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1680), "148506E98B3E74992CFF915C8CBD5591", new Guid("a116eced-dd57-49ed-898e-3ffb1841405f"), "Student" },
                    { new Guid("e8784de4-3214-413a-86f5-0c426ac571b4"), new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1790), "test3test3@ku.edu.tr", "test3", "test33", false, new DateTime(2022, 12, 4, 15, 32, 23, 97, DateTimeKind.Local).AddTicks(1790), "148506E98B3E74992CFF915C8CBD5591", new Guid("3d72d930-573e-4d85-b43f-340cff1f4c26"), "Student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseData");

            migrationBuilder.DropTable(
                name: "CourseStudentData");

            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
