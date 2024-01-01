using LaundroMat.Entities;

namespace LaundroMat.Services
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<bool> UserExistsAsync(string email);
        Task<bool> SaveAsync();
    }
}
