
namespace Infrastructure.Authorization
{
    public class JwtOptions
    {
        public JwtOptions(string issuerUrl, string audienceUrl, string secretKey)
        {
            IssuerUrl = issuerUrl;
            AudienceUrl = audienceUrl;
            SecretKey = secretKey;
        }

        public string IssuerUrl { get; }

        public string AudienceUrl { get; }

        public string SecretKey { get; }
    }
}
