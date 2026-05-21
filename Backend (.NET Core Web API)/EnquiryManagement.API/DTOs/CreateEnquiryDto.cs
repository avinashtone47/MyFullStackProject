namespace EnquiryManagement.API.DTOs
{
    public class CreateEnquiryDto
    {
        public string CustomerName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
