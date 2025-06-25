using ZipZop.Data;
using ZipZop.Helpers;
using ZipZop.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZipZop.Modals;
using Microsoft.AspNetCore.Identity;

namespace ZipZop.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public UserService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<string> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                return "User already exists";

            var hasher = new PasswordHasher<User>();
            user.PasswordHash = hasher.HashPassword(user, user.PasswordHash); // 🔐 Hash password
            user.Role = "Customer";

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "Registration successful";
        }

        public async Task<string?> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password); 

            if (result == PasswordVerificationResult.Failed)
                return null;

            return JwtTokenHelpers.GenerateToken(user, _config);
        }

    }
}
