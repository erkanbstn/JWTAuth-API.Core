namespace AuthServer.Core.Core.Dtos
{
    public class ClientTokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}