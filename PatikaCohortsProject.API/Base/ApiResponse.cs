namespace PatikaCohortsProject.API.Base;

public class ApiResponse<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public ApiResponse(int statusCode, string message, T data = default)
    {
        StatusCode = statusCode;
        Data = data;
        Message = message;
    }
    public ApiResponse(T data)
    {
        this.Data = data;
        this.IsSuccess = true;
        this.Message = string.Empty;
    }
    public ApiResponse(string message)
    {
        this.IsSuccess = false;
        this.Message = message;
    }
}
