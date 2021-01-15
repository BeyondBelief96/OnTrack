using Microsoft.EntityFrameworkCore;
using OnTrack.Framework.Models;

namespace OnTrack.EntityFramework
{
    public class OnTrackDbContext : DbContext
    {
        #region Entities

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<StudentLoan> StudentLoans { get; set; }

        public DbSet<LoanInfo> AccountLoanInfo { get; set; }

        #endregion

        #region Config

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        #endregion
    }
}
