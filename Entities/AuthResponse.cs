namespace backTOT.Entities
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        // Thời hạn sống của Access Token
        public DateTime AccessTokenExpiration { get; set; }

        // Thời hạn sống của Refresh Token
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
