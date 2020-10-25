using Database.Tables;

namespace WebApiServer.Models
{
    public class TokenCheckResult
    {
        public bool Logged { get; set; }
        public AccountType AccountType { get; set; }
        public int userID { get; set; }
    }
}