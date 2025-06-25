using System.Threading.Tasks;
using ZipZop.dtos;
using ZipZop.Modals;

namespace ZipZop.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> Register(RegisterUserDto dto);
        Task<string?> Login(string email, string password);
    }
}
