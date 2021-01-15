namespace OnTrack.Framework.Models
{
    public class StudentLoan
    {
        #region Properties

        public Account LoanHolder { get; set; }

        public bool IsConsolidated { get; set; }

        public double TotalBalance { get; set; }

        public LoanInfo[] Loans { get; set; }

        #endregion
    }
}
