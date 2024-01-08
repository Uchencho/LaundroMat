using LaundroMat.Entities;

namespace LaundroMat.Services
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<bool> UserExistsAsync(string email);
        Task<User> GetUserAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
