namespace ClassManagement.Api.DTOs
{
    public class ApiResponse
    {
        public string? Message { get; set; }
        public bool? Success { get; set; }
        public object Payload { get; set; }
    }
}
