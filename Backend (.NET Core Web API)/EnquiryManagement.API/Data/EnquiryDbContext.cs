using EnquiryManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EnquiryManagement.API.Data
{
    public class EnquiryDbContext : DbContext
    {
        public EnquiryDbContext(DbContextOptions<EnquiryDbContext> options) : base(options)
        {
        }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
