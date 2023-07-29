namespace AuthServer.Core.Core.Configuration
{
    public class Client
    {
        public int Id { get; set; }
        public int Secret { get; set; }
        public List<String> Audiences{ get; set; }
    }
}