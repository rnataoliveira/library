using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace library.Models.migrations
{
    public partial class AddingReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableCopies",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Copies",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Number = table.Column<Guid>(nullable: false),
                    AcademicRecord = table.Column<string>(nullable: true),
                    BookIsbn = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Reservations_Books_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Books",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookIsbn",
                table: "Reservations",
                column: "BookIsbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropColumn(
                name: "AvailableCopies",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Copies",
                table: "Books");
        }
    }
}
