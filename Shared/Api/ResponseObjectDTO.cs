namespace Shared.Api
{
    public class ResponseObjectDTO<T> where T : class
    {
        public ResponseObjectDTO(string? title, T? results)
        {
            Title = title;
            Results = results;
        }

        public string? Title { get; set; }
        public int Status { get; set; } = 200;
        public T? Results { get; set; }
    }
}
