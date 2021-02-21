namespace AnimalBalanceApp.Core.CustomEntities
{
    public class AuthenticationOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresToken { get; set; }
        public string ExpireTokenText { get; set; }
    }
}
