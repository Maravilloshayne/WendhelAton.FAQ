﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WendhelAton.FAQ.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TemplateName = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LoginStatus = table.Column<int>(nullable: false),
                    RegistrationCode = table.Column<string>(nullable: true),
                    LoginTrials = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Threads");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
