namespace Shared.Api
{
    public class ResponseListObjectDTO<T> where T : class
    {
        public ResponseListObjectDTO(string? title, ICollection<T>? results)
        {
            Title = title;
            Results = results;
        }

        public ResponseListObjectDTO(string? title, ICollection<T>? results, int page, int totalPage, int totalCount)
        {
            Title = title;
            Results = results;
            Page = page;
            TotalPage = totalPage;
            TotalCount = totalCount;
        }

        public string? Title { get; set; }
        public int Status { get; set; } = 200;
        public ICollection<T>? Results { get; set; }
        public int Page { get; set; } = 1;
        public int TotalPage { get; set; } = 1;
        public int TotalCount { get; set; } = 1;
    }
}
