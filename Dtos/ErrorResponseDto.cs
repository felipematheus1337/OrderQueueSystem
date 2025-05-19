namespace OrderQueueSystem.Dtos;

public class ErrorResponseDto
{
    public int StatusCode { get; }
    public string Message { get; }
    public string Endpoint { get; }
    public DateTime Timestamp { get; }

    public ErrorResponseDto(int statusCode, string message, string endpoint, DateTime timestamp)
    {
        StatusCode = statusCode;
        Message = message;
        Endpoint = endpoint;
        Timestamp = timestamp;
    }

}
