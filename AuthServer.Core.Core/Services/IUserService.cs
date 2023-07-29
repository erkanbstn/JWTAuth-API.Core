using AuthServer.Core.Core.Dtos;
using AuthServer.Core.Shared.Dtos;

namespace AuthServer.Core.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);
    }
}