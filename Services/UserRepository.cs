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

        public async Task<User> GetUserAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user ?? throw new Exception("user with id does not exist");
        }
    }
}
