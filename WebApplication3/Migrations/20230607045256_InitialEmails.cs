using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class InitialEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyEmployees");

            migrationBuilder.DropTable(
                name: "employeesHss");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "departmentCompanies");

            migrationBuilder.DropTable(
                name: "EmployeesForTasks");

            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    emailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    hasAttachment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emails", x => x.emailId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emails");

            migrationBuilder.CreateTable(
                name: "departmentCompanies",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hasEmployee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departmentCompanies", x => x.departmentId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesForTasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesForTasks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "employeesHss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Head_ID = table.Column<int>(type: "int", nullable: false),
                    Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesHss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companyEmployees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyEmployees", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_companyEmployees_departmentCompanies_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departmentCompanies",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Task_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Assigned_EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Has_Items = table.Column<bool>(type: "bit", nullable: false),
                    Task_Assigned_Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Task_Completion = table.Column<int>(type: "int", nullable: false),
                    Task_Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task_Owner_ID = table.Column<int>(type: "int", nullable: false),
                    Task_Parent_ID = table.Column<int>(type: "int", nullable: false),
                    Task_Priority = table.Column<int>(type: "int", nullable: false),
                    Task_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Task_ID);
                    table.ForeignKey(
                        name: "FK_Tasks_EmployeesForTasks_Task_Assigned_EmployeeID",
                        column: x => x.Task_Assigned_EmployeeID,
                        principalTable: "EmployeesForTasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companyEmployees_DepartmentId",
                table: "companyEmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Task_Assigned_EmployeeID",
                table: "Tasks",
                column: "Task_Assigned_EmployeeID");
        }
    }
}
