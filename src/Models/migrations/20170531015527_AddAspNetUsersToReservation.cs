using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Models.migrations
{
    public partial class AddAspNetUsersToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcademicRecord",
                table: "Reservations",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservations",
                newName: "AcademicRecord");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicRecord",
                table: "Reservations",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
