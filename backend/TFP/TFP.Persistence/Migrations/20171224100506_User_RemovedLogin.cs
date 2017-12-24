using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TFP.Persistence.Migrations
{
    public partial class User_RemovedLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                schema: "Membership",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                schema: "Membership",
                table: "User",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
