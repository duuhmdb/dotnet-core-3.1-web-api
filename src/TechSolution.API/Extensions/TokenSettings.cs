namespace TechSolution.API.Extensions
{
    public class TokenSettings
    {
        public string Secret { get; set; }
        public int ExpiresIn { get; set; }
        public string Issuer { get; set; }
        public string Auditor { get; set; }
    }
}
