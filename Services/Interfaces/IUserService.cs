using ZipZop.dtos;
using ZipZop.Modals;

namespace ZipZop.Services.Interfaces
{
    public interface IUserService
    {
      
        Task<string?> Login(string email, string password);
    }
}
