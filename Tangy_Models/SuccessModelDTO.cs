namespace Tangy_Models
{
    public class SuccessModelDTO
    {
        public int StatusCode { get; set; }
        public string SuccessMessage { get; set; } = string.Empty;
        public required object Data { get; set; }
    }
}
