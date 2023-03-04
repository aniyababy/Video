using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Video.EntityFrameworkCore.Migrations
{
    public partial class initadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eebf0d71-d511-42ba-b474-7f47e7e45bcd"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("e87064b5-354a-4f93-89b9-ee5958046ee7"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2e396a7-a104-4433-b357-09152d230b5d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreateTime", "Name" },
                values: new object[] { new Guid("18aaa639-68fd-4c91-8ece-21509c8999e1"), "admin1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Avatar", "CreateTime", "Enable", "Name", "Password", "Username" },
                values: new object[] { new Guid("646a26fa-7877-441c-b390-df81f50e5b6d"), "", new DateTime(2023, 3, 2, 16, 55, 57, 404, DateTimeKind.Local).AddTicks(9934), true, "admin1", "admin1", "admin1" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreateTime", "RoleId", "UserId" },
                values: new object[] { new Guid("7ae36cec-70a7-46ef-b92a-356525babf4f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("18aaa639-68fd-4c91-8ece-21509c8999e1"), new Guid("646a26fa-7877-441c-b390-df81f50e5b6d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("18aaa639-68fd-4c91-8ece-21509c8999e1"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("646a26fa-7877-441c-b390-df81f50e5b6d"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ae36cec-70a7-46ef-b92a-356525babf4f"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreateTime", "Name" },
                values: new object[] { new Guid("eebf0d71-d511-42ba-b474-7f47e7e45bcd"), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aniya" });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Avatar", "CreateTime", "Enable", "Name", "Password", "Username" },
                values: new object[] { new Guid("e87064b5-354a-4f93-89b9-ee5958046ee7"), "", new DateTime(2023, 3, 2, 16, 41, 45, 333, DateTimeKind.Local).AddTicks(7074), true, "aniya", "aniya", "aniya" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreateTime", "RoleId", "UserId" },
                values: new object[] { new Guid("a2e396a7-a104-4433-b357-09152d230b5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eebf0d71-d511-42ba-b474-7f47e7e45bcd"), new Guid("e87064b5-354a-4f93-89b9-ee5958046ee7") });
        }
    }
}
