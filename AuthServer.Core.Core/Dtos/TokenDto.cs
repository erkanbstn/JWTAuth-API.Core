namespace AuthServer.Core.Core.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiration{ get; set; }
        public DateTime RefreshTokenExpiration{ get; set; }
    }
}