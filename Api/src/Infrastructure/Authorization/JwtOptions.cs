
namespace Infrastructure.Authorization
{
    internal class JwtOptions
    {
        internal JwtOptions(string issuerUrl, string audienceUrl, string secretKey)
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
