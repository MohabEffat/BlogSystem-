namespace BlogSystem.Infrastructure.OptionsSetup
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public TimeSpan ExpiryTimeFrame { get; set; }
    }
}
