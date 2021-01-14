namespace OnTrack.Framework.Models
{
    public class User
    {
        #region Properties

        public Account Account { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        #endregion
    }
}
