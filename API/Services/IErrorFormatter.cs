namespace API.Services
{
    public interface IErrorFormatter
    {
        string FormatError(int code, string message = null, string details = null);
    }
}
