namespace BlogSystem.Infrastructure.HandleResponse
{
    public class CustomException : Response
    {
        public CustomException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        {
            Details = details;
        }
        public string? Details { get; set; }
    }
}
