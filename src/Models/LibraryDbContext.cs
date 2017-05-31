using Microsoft.EntityFrameworkCore;
using Library.Features.Reservation.DomainModel;
using Library.Features.BookCatalog.DomainModel;
using Library.Features.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasKey(entity => entity.Number)
                .HasName("Id");
        }
    }
}