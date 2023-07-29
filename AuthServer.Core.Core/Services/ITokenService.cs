using AuthServer.Core.Core.Configuration;
using AuthServer.Core.Core.Dtos;
using AuthServer.Core.Core.Model;

namespace AuthServer.Core.Core.GenericService
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}