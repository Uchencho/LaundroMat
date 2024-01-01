using LaundroMat.DBContexts;
using LaundroMat.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaundroMat.Services
{
    public class UserRepository : IUserRepository
    {

        private readonly LaundroMatContext _context;

        public UserRepository(LaundroMatContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async void AddUser(User user)
        {
            bool userExists = await UserExistsAsync(user.Email);
            if (userExists)
            {
                throw new Exception("user already exists");
            }

            _context.Users.Add(user);
        }

         public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> SaveAsync()
        {
           return await _context.SaveChangesAsync() >= 0;
        }
    }
}
