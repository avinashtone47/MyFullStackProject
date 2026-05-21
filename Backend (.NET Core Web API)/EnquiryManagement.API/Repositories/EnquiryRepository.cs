using EnquiryManagement.API.Data;
using EnquiryManagement.API.Interfaces;
using EnquiryManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EnquiryManagement.API.Repositories
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly EnquiryDbContext _context;

        public EnquiryRepository(EnquiryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enquiry>> GetAllAsync()
        {
            return await _context.Enquiries.ToListAsync();
        }

        public async Task<Enquiry?> GetByIdAsync(int id)
        {
            return await _context.Enquiries.FindAsync(id);
        }

        public async Task AddAsync(Enquiry enquiry)
        {
            await _context.Enquiries.AddAsync(enquiry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enquiry enquiry)
        {
            _context.Enquiries.Update(enquiry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Enquiry enquiry)
        {
            _context.Enquiries.Remove(enquiry);
            await _context.SaveChangesAsync();
        }
    }
}
