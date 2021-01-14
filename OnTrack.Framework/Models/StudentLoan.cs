namespace OnTrack.Framework.Models
{
    public class StudentLoan
    {
        #region Properties

        public bool IsConsolidated { get; set; }

        public double TotalBalance { get; set; }

        public LoanInfo[] Loans { get; set; }

        #endregion
    }
}
