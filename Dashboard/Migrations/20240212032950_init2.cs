using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentManagerId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentManagerId",
                table: "Department",
                column: "DepartmentManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_DepartmentManagerId",
                table: "Department",
                column: "DepartmentManagerId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_DepartmentManagerId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DepartmentManagerId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DepartmentManagerId",
                table: "Department");
        }
    }
}
