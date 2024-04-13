namespace UniversityApiBackend.Models.DataModels
{
    public class JwtSettings
    {

        public bool ValidateIssuerSinginKey { get; set; }

        public string IssuerSingingKey { get; set; } = string.Empty;

        public bool ValidateIssuer {  get; set; } = true;

        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; } = true;

        public string? ValidAudience { get; set; }

        public bool RequireExpirationTime { get; set; } = true;

        public bool ValidateLifetime { get; set; } = true;
    }
}
