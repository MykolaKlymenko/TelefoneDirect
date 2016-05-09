namespace TelefoneDictionary
{
    public interface ILogger
    {
        void Log(string text);
        void LogError(string text);
    }
}