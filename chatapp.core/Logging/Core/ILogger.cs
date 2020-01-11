namespace chatapp.core
{
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}