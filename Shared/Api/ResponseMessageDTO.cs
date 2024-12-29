namespace Shared.Api
{
    public class ResponseMessageDTO
    {
        public ResponseMessageDTO(string? title, int status, ICollection<dynamic> messages)
        {
            Title = title;
            Status = status;
            Messages = messages;
        }

        public string? Title { get; set; }
        public int Status { get; set; } = 200;
        public ICollection<dynamic>? Messages { get; set; }
    }
}
