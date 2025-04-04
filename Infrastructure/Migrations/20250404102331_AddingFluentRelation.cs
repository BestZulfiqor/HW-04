using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingFluentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Course_CourseId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroup_Group_GroupId",
                table: "StudentGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroup_Students_StudentId",
                table: "StudentGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroup",
                table: "StudentGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "StudentGroup",
                newName: "StudentGroups");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroup_GroupId",
                table: "StudentGroups",
                newName: "IX_StudentGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_CourseId",
                table: "Groups",
                newName: "IX_Groups_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StudentId",
                table: "Addresses",
                newName: "IX_Addresses_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroups",
                table: "StudentGroups",
                columns: new[] { "StudentId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Students_StudentId",
                table: "Addresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroups_Groups_GroupId",
                table: "StudentGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroups_Students_StudentId",
                table: "StudentGroups",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Students_StudentId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Courses_CourseId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroups_Groups_GroupId",
                table: "StudentGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroups_Students_StudentId",
                table: "StudentGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroups",
                table: "StudentGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "StudentGroups",
                newName: "StudentGroup");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroups_GroupId",
                table: "StudentGroup",
                newName: "IX_StudentGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_CourseId",
                table: "Group",
                newName: "IX_Group_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StudentId",
                table: "Address",
                newName: "IX_Address_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroup",
                table: "StudentGroup",
                columns: new[] { "StudentId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Course_CourseId",
                table: "Group",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroup_Group_GroupId",
                table: "StudentGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroup_Students_StudentId",
                table: "StudentGroup",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
