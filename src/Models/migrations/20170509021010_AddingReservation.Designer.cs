using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Library.Models;

namespace library.Models.migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20170509021010_AddingReservation")]
    partial class AddingReservation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<string>("Isbn")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int>("AvailableCopies");

                    b.Property<int>("Copies");

                    b.Property<string>("Cover");

                    b.Property<string>("Description");

                    b.Property<string>("Subject");

                    b.Property<string>("Title");

                    b.HasKey("Isbn");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.ReservationContext.DomainModel.Reservation", b =>
                {
                    b.Property<Guid>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcademicRecord");

                    b.Property<string>("BookIsbn");

                    b.Property<DateTime>("ReservationDate");

                    b.HasKey("Number")
                        .HasName("Id");

                    b.HasIndex("BookIsbn");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Library.ReservationContext.DomainModel.Reservation", b =>
                {
                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookIsbn");
                });
        }
    }
}
