using EnquiryManagement.API.Models;

namespace EnquiryManagement.API.Interfaces
{
    public interface IEnquiryRepository
    {
        Task<IEnumerable<Enquiry>> GetAllAsync();

        Task<Enquiry?> GetByIdAsync(int id);

        Task AddAsync(Enquiry enquiry);

        Task UpdateAsync(Enquiry enquiry);

        Task DeleteAsync(Enquiry enquiry);
    }
}
