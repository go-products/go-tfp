using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TFP.Persistence.Migrations
{
    public partial class Individual_RemovedUnusedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membership_User_Membership_Individual",
                schema: "Membership",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_User_Membership_PermissionSet",
                schema: "Membership",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Membership",
                table: "Individual");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Membership",
                table: "Individual");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Membership",
                table: "Individual");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Membership",
                table: "Individual",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Individual_UserId",
                schema: "Membership",
                table: "Individual",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_User_UserId",
                schema: "Membership",
                table: "Individual",
                column: "UserId",
                principalSchema: "Membership",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_PermissionSet_InitialPermissionSetId",
                schema: "Membership",
                table: "User",
                column: "InitialPermissionSetId",
                principalSchema: "Membership",
                principalTable: "PermissionSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individual_User_UserId",
                schema: "Membership",
                table: "Individual");

            migrationBuilder.DropForeignKey(
                name: "FK_User_PermissionSet_InitialPermissionSetId",
                schema: "Membership",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Individual_UserId",
                schema: "Membership",
                table: "Individual");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Membership",
                table: "Individual");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Membership",
                table: "Individual",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Membership",
                table: "Individual",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Membership",
                table: "Individual",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_User_Membership_Individual",
                schema: "Membership",
                table: "User",
                column: "Id",
                principalSchema: "Membership",
                principalTable: "Individual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_User_Membership_PermissionSet",
                schema: "Membership",
                table: "User",
                column: "InitialPermissionSetId",
                principalSchema: "Membership",
                principalTable: "PermissionSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
