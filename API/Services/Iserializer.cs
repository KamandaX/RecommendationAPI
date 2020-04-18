namespace API.Services
{
    public interface Iserializer
    {
        string Encode<T>(T obj);

        T Decode<T>(string data);
    }
}
