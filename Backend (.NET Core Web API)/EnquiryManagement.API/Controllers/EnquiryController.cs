using EnquiryManagement.API.DTOs;
using EnquiryManagement.API.Interfaces;
using EnquiryManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnquiryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryRepository _repository;

        public EnquiryController(IEnquiryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnquiries()
        {
            var enquiries = await _repository.GetAllAsync();

            return Ok(enquiries);
        }



        [HttpPost]
        public async Task<IActionResult> CreateEnquiry(CreateEnquiryDto dto)
        {
            var enquiry = new Enquiry
            {
                CustomerName = dto.CustomerName,
                Email = dto.Email,
                Phone = dto.Phone,
                Subject = dto.Subject,
                Message = dto.Message
            };

            await _repository.AddAsync(enquiry);

            return Ok(new
            {
                message = "Enquiry created successfully"
            });
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnquiryById(int id)
        {
            var enquiry = await _repository.GetByIdAsync(id);

            if (enquiry == null)
            {
                return NotFound(new
                {
                    message = "Enquiry not found"
                });
            }

            return Ok(enquiry);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnquiry(int id, UpdateEnquiryDto dto)
        {
            var enquiry = await _repository.GetByIdAsync(id);

            if (enquiry == null)
            {
                return NotFound(new
                {
                    message = "Enquiry not found"
                });
            }

            enquiry.CustomerName = dto.CustomerName;
            enquiry.Email = dto.Email;
            enquiry.Phone = dto.Phone;
            enquiry.Subject = dto.Subject;
            enquiry.Message = dto.Message;
            enquiry.Status = dto.Status;
            enquiry.UpdatedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(enquiry);

            return Ok(new
            {
                message = "Enquiry updated successfully"
            });
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnquiry(int id)
        {
            var enquiry = await _repository.GetByIdAsync(id);

            if (enquiry == null)
            {
                return NotFound(new
                {
                    message = "Enquiry not found"
                });
            }

            await _repository.DeleteAsync(enquiry);

            return Ok(new
            {
                message = "Enquiry deleted successfully"
            });
        }


    }
}
