using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Models.migrations
{
    public partial class AddingIsAvailableCopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForReservation",
                table: "Books",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailableForReservation",
                table: "Books");
        }
    }
}
