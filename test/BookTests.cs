using System;
using Library.Models;
using Xunit;
using Shouldly;
using Library.Features.BookCatalog.DomainModel;

namespace Library.Tests
{
    public class BookTests
    {
        [Fact(DisplayName = "Reserva não permitida se existem exemplares disponiveis.")]
        public void ShouldNotAllowToReservationIfAvailableCopiesAreBiggerThanZero()
        {
            var book = new Book("000000", 10);

            book.IsAvailableForReservation.ShouldBeFalse();
        }
    }
}
