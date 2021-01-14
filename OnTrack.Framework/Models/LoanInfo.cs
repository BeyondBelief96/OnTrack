namespace OnTrack.Framework.Models
{
    public class LoanInfo
    {
        #region Properties
        
        public double Principal { get; set; }

        public double Interest { get; set; }

        public double InterestRate { get; set; }

        public bool IsSubsidized { get; set; }

        #endregion
    }
}
