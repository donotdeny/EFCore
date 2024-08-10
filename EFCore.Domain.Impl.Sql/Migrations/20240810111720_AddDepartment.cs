using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Domain.Impl.Sql.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrentDepartmentId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CurrentDepartmentId",
                table: "Employees",
                column: "CurrentDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_CurrentDepartmentId",
                table: "Employees",
                column: "CurrentDepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_CurrentDepartmentId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CurrentDepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CurrentDepartmentId",
                table: "Employees");
        }
    }
}
