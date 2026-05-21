using EnquiryManagement.API.Models;

namespace EnquiryManagement.API.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task RegisterUserAsync(User user);
    }
}
