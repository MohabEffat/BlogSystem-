namespace BlogSystem.Infrastructure.HandleResponse
{
    public class ValidationResponse : CustomException
    {
        public ValidationResponse() : base(400)
        {

        }
        public IEnumerable<string>? Errors { get; set; }

    }
}
