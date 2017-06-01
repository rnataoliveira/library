using System;
using Library.Features.Account;
using Microsoft.AspNetCore.Identity;

namespace Library.Features.Lending.DomainModel
{
    public interface ILendingExpirationService
    {
        DateTime ApplyExpirationPoliceFor(ApplicationUser user, DateTime startDate);
    }

    public class LendingExpirationService : ILendingExpirationService
    {
        readonly UserManager<ApplicationUser> _userManager;

        public LendingExpirationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public DateTime ApplyExpirationPoliceFor(ApplicationUser user, DateTime startDate)
        {
            if (_userManager.IsInRoleAsync(user, "Staff").Result)
                return startDate.AddDays(14);
            if (_userManager.IsInRoleAsync(user, "Student").Result)
                return startDate.AddDays(7);

            throw new Exception("Cannot apply expiration police for user.");
        }
    }
}