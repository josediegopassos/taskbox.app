namespace TaskBox.Infra.CrossCutting.Logger.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string infoMessage);
        void LogWarning(string warningMessage);
        void LogError(string errorMessage);
        void LogError(Exception ex);
        void LogError(Exception ex, string errorMessage);
        void LogFatal(string errorMessage);
        void LogFatal(Exception ex);
        void LogFatal(Exception ex, string errorMessage);
        Task LogInfoAsync(string infoMessage);
        Task LogWarningAsync(string warningMessage);
        Task LogErrorAsync(string errorMessage);
        Task LogErrorAsync(Exception ex);
        Task LogErrorAsync(Exception ex, string errorMessage);
        Task LogFatalAsync(string errorMessage);
        Task LogFatalAsync(Exception ex);
        Task LogFatalAsync(Exception ex, string errorMessage);
    }
}
