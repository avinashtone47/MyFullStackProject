using EnquiryManagement.API.Data;
using EnquiryManagement.API.Interfaces;
using EnquiryManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EnquiryManagement.API.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly EnquiryDbContext _context;

        public UserRepository(EnquiryDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task RegisterUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }
    }
}
