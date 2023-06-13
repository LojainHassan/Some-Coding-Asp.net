using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class intita28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Tasks",
                columns: table => new
                {
                    Task_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Parent_ID = table.Column<int>(type: "int", nullable: false),
                    Task_Assigned_Employee_ID = table.Column<int>(type: "int", nullable: false),
                    Task_Assigned_EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Task_Owner_ID = table.Column<int>(type: "int", nullable: false),
                    Task_Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task_Due_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_Priority = table.Column<int>(type: "int", nullable: false),
                    Task_Completion = table.Column<int>(type: "int", nullable: false),
                    Has_Items = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_Tasks_Task_Assigned_EmployeeID",
                table: "Tasks",
                column: "Task_Assigned_EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "EmployeesForTasks");
        }
    }
}
