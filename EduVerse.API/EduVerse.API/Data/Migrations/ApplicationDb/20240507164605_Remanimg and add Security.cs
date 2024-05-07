using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduVerse.API.Migrations
{
    /// <inheritdoc />
    public partial class RemanimgandaddSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Schedule_ScheduleLessonId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Student_StudentId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Schedule_ScheduleLessonId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Student_StudentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Teacher_CuratorId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLessons_Group_GroupsId",
                table: "GroupLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLessons_Lesson_LessonsId",
                table: "GroupLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsChildrens_Parent_ParentsId",
                table: "ParentsChildrens");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsChildrens_Student_ChildrensId",
                table: "ParentsChildrens");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Group_GroupId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Lesson_LessonId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Teacher_TeacherId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherLessons_Lesson_LessonsId",
                table: "TeacherLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherLessons_Teacher_TeachersId",
                table: "TeacherLessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27e1b952-75ad-4302-95e5-eebcaab89f5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35cdac50-ad23-4d32-ad99-e71144d2e4e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fbcbec3-ddc7-4ff8-85cf-c1ffba0c55f0");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "Parents");

            migrationBuilder.RenameTable(
                name: "Lesson",
                newName: "Lessons");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_PhoneNumber",
                table: "Teachers",
                newName: "IX_Teachers_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_LastName_FirstName_DateOfBirth",
                table: "Teachers",
                newName: "IX_Teachers_LastName_FirstName_DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Student_PhoneNumber",
                table: "Students",
                newName: "IX_Students_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Student_LastName_FirstName_DateOfBirth",
                table: "Students",
                newName: "IX_Students_LastName_FirstName_DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GroupId",
                table: "Students",
                newName: "IX_Students_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_TeacherId",
                table: "Schedules",
                newName: "IX_Schedules_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_LessonId",
                table: "Schedules",
                newName: "IX_Schedules_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_GroupId",
                table: "Schedules",
                newName: "IX_Schedules_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_DayOfWeek_Time_GroupId",
                table: "Schedules",
                newName: "IX_Schedules_DayOfWeek_Time_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_PhoneNumber",
                table: "Parents",
                newName: "IX_Parents_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_LastName_FirstName_DateOfBirth",
                table: "Parents",
                newName: "IX_Parents_LastName_FirstName_DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Lesson_Name",
                table: "Lessons",
                newName: "IX_Lessons_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Group_GroupName",
                table: "Groups",
                newName: "IX_Groups_GroupName");

            migrationBuilder.RenameIndex(
                name: "IX_Group_CuratorId",
                table: "Groups",
                newName: "IX_Groups_CuratorId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_StudentId",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_ScheduleLessonId",
                table: "Grades",
                newName: "IX_Grades_ScheduleLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_Date_StudentId_ScheduleLessonId",
                table: "Grades",
                newName: "IX_Grades_Date_StudentId_ScheduleLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendances",
                newName: "IX_Attendances_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ScheduleLessonId",
                table: "Attendances",
                newName: "IX_Attendances_ScheduleLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_Date_StudentId_ScheduleLessonId",
                table: "Attendances",
                newName: "IX_Attendances_Date_StudentId_ScheduleLessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "378a35ae-bfa9-4713-9fd1-f16b4c4cbb4e", null, "Parent", "PARENT" },
                    { "495be55f-7a75-4dd0-83fa-6097bcea28d3", null, "Teacher", "TEACHER" },
                    { "b3352893-5da2-4058-bb6a-f863dfd77e8c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Schedules_ScheduleLessonId",
                table: "Attendances",
                column: "ScheduleLessonId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Schedules_ScheduleLessonId",
                table: "Grades",
                column: "ScheduleLessonId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLessons_Groups_GroupsId",
                table: "GroupLessons",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLessons_Lessons_LessonsId",
                table: "GroupLessons",
                column: "LessonsId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Teachers_CuratorId",
                table: "Groups",
                column: "CuratorId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsChildrens_Parents_ParentsId",
                table: "ParentsChildrens",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsChildrens_Students_ChildrensId",
                table: "ParentsChildrens",
                column: "ChildrensId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Lessons_LessonId",
                table: "Schedules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherLessons_Lessons_LessonsId",
                table: "TeacherLessons",
                column: "LessonsId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherLessons_Teachers_TeachersId",
                table: "TeacherLessons",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Schedules_ScheduleLessonId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Schedules_ScheduleLessonId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLessons_Groups_GroupsId",
                table: "GroupLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupLessons_Lessons_LessonsId",
                table: "GroupLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Teachers_CuratorId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsChildrens_Parents_ParentsId",
                table: "ParentsChildrens");

            migrationBuilder.DropForeignKey(
                name: "FK_ParentsChildrens_Students_ChildrensId",
                table: "ParentsChildrens");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Groups_GroupId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Lessons_LessonId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_TeacherId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherLessons_Lessons_LessonsId",
                table: "TeacherLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherLessons_Teachers_TeachersId",
                table: "TeacherLessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "378a35ae-bfa9-4713-9fd1-f16b4c4cbb4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "495be55f-7a75-4dd0-83fa-6097bcea28d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3352893-5da2-4058-bb6a-f863dfd77e8c");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "Parent");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "Lesson");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_PhoneNumber",
                table: "Teacher",
                newName: "IX_Teacher_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_LastName_FirstName_DateOfBirth",
                table: "Teacher",
                newName: "IX_Teacher_LastName_FirstName_DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PhoneNumber",
                table: "Student",
                newName: "IX_Student_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Students_LastName_FirstName_DateOfBirth",
                table: "Student",
                newName: "IX_Student_LastName_FirstName_DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupId",
                table: "Student",
                newName: "IX_Student_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedule",
                newName: "IX_Schedule_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_LessonId",
                table: "Schedule",
                newName: "IX_Schedule_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_GroupId",
                table: "Schedule",
                newName: "IX_Schedule_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_DayOfWeek_Time_GroupId",
                table: "Schedule",
                newName: "IX_Schedule_DayOfWeek_Time_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_PhoneNumber",
                table: "Parent",
                newName: "IX_Parent_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_LastName_FirstName_DateOfBirth",
                table: "Parent",
                newName: "IX_Parent_LastName_FirstName_DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_Name",
                table: "Lesson",
                newName: "IX_Lesson_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_GroupName",
                table: "Group",
                newName: "IX_Group_GroupName");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_CuratorId",
                table: "Group",
                newName: "IX_Group_CuratorId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grade",
                newName: "IX_Grade_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_ScheduleLessonId",
                table: "Grade",
                newName: "IX_Grade_ScheduleLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_Date_StudentId_ScheduleLessonId",
                table: "Grade",
                newName: "IX_Grade_Date_StudentId_ScheduleLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendance",
                newName: "IX_Attendance_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ScheduleLessonId",
                table: "Attendance",
                newName: "IX_Attendance_ScheduleLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_Date_StudentId_ScheduleLessonId",
                table: "Attendance",
                newName: "IX_Attendance_Date_StudentId_ScheduleLessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lesson",
                table: "Lesson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27e1b952-75ad-4302-95e5-eebcaab89f5a", null, "Teacher", "TEACHER" },
                    { "35cdac50-ad23-4d32-ad99-e71144d2e4e9", null, "Admin", "ADMIN" },
                    { "6fbcbec3-ddc7-4ff8-85cf-c1ffba0c55f0", null, "Parent", "PARENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Schedule_ScheduleLessonId",
                table: "Attendance",
                column: "ScheduleLessonId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Student_StudentId",
                table: "Attendance",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Schedule_ScheduleLessonId",
                table: "Grade",
                column: "ScheduleLessonId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Student_StudentId",
                table: "Grade",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Teacher_CuratorId",
                table: "Group",
                column: "CuratorId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLessons_Group_GroupsId",
                table: "GroupLessons",
                column: "GroupsId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupLessons_Lesson_LessonsId",
                table: "GroupLessons",
                column: "LessonsId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsChildrens_Parent_ParentsId",
                table: "ParentsChildrens",
                column: "ParentsId",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParentsChildrens_Student_ChildrensId",
                table: "ParentsChildrens",
                column: "ChildrensId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Group_GroupId",
                table: "Schedule",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Lesson_LessonId",
                table: "Schedule",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teacher_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherLessons_Lesson_LessonsId",
                table: "TeacherLessons",
                column: "LessonsId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherLessons_Teacher_TeachersId",
                table: "TeacherLessons",
                column: "TeachersId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
