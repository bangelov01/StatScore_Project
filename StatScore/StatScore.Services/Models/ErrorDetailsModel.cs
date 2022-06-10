namespace StatScore.Services.Models
{
    using System.Text.Json;

    public class ErrorDetailsModel
    {
        public int StatusCode { get; init; }
        public string Message { get; init; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
