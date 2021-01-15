namespace OnTrack.Framework.Models
{
    public class Account
    {
        #region Properties

        public int id { get; set; }

        public double NetMonthlyIncome { get; set; }

        public StudentLoan Loan { get; set; }

        #endregion 
    }
}
