using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Video.EntityFrameworkCore.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("0b883e3c-f2ef-488a-b91b-de72de420b98"), "user", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" },
                    { new Guid("72f24682-661b-4cc2-8c0a-05848239da8c"), "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Id", "Avatar", "CreateTime", "Enable", "Name", "Password", "Username" },
                values: new object[] { new Guid("4cf883d4-43f5-48ba-821e-6d236408fd5b"), "", new DateTime(2023, 3, 4, 16, 20, 25, 267, DateTimeKind.Local).AddTicks(5515), true, "admin", "adminn", "adminn" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreateTime", "RoleId", "UserId" },
                values: new object[] { new Guid("ae27e789-b199-421f-a17c-09616e224557"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("72f24682-661b-4cc2-8c0a-05848239da8c"), new Guid("4cf883d4-43f5-48ba-821e-6d236408fd5b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0b883e3c-f2ef-488a-b91b-de72de420b98"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72f24682-661b-4cc2-8c0a-05848239da8c"));

            migrationBuilder.DeleteData(
                table: "UserInfo",
                keyColumn: "Id",
                keyValue: new Guid("4cf883d4-43f5-48ba-821e-6d236408fd5b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae27e789-b199-421f-a17c-09616e224557"));

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
    }
}
