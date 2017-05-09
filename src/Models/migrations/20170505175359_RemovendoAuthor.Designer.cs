using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Library.Models;

namespace library.models.migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20170505175359_RemovendoAuthor")]
    partial class RemovendoAuthor
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

                    b.Property<string>("Cover");

                    b.Property<string>("Description");

                    b.Property<string>("Subject");

                    b.Property<string>("Title");

                    b.HasKey("Isbn");

                    b.ToTable("Books");
                });
        }
    }
}
