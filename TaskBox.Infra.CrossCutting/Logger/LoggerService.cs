using TaskBox.Infra.CrossCutting.Logger.Interfaces;

namespace TaskBox.Infra.CrossCutting.Logger
{
    public class LoggerService : ILoggerService
    {
        public void LogInfo(string infoMessage)
        {
            Console.Out.WriteLine($"[INFO]: {infoMessage}");
        }

        public void LogWarning(string warningMessage)
        {
            Console.Out.WriteLine($"[WARNING]: {warningMessage}");
        }

        public void LogError(string errorMessage)
        {
            Console.Error.WriteLine($"[ERROR]: {errorMessage}");
        }

        public void LogError(Exception ex)
        {
            Console.Error.WriteLine($"[ERROR]: {ex.GetErrorMsg()}, [EXCEPTION]: {ex}");
        }

        public void LogError(Exception ex, string errorMessage)
        {
            Console.Error.WriteLine($"[ERROR]: {errorMessage}, [EXCEPTION]: {ex}");
        }

        public void LogFatal(string errorMessage)
        {
            Console.Error.WriteLine($"[FATAL ERROR]: {errorMessage}");
        }

        public void LogFatal(Exception ex)
        {
            Console.Error.WriteLine($"[FATAL ERROR]: {ex.GetErrorMsg()}, [EXCEPTION]: {ex}");
        }

        public void LogFatal(Exception ex, string errorMessage)
        {
            Console.Error.WriteLine($"[FATAL ERROR]: {errorMessage}, [EXCEPTION]: {ex}");
        }

        public async Task LogInfoAsync(string infoMessage)
        {
            await Console.Out.WriteLineAsync($"[INFO]: {infoMessage}");
        }

        public async Task LogWarningAsync(string warningMessage)
        {
            await Console.Out.WriteLineAsync($"[WARNING]: {warningMessage}");
        }

        public async Task LogErrorAsync(string errorMessage)
        {
            await Console.Error.WriteLineAsync($"[ERROR]: {errorMessage}");
        }

        public async Task LogErrorAsync(Exception ex)
        {
            await Console.Error.WriteLineAsync($"[ERROR]: {ex.GetErrorMsg()}, [EXCEPTION]: {ex}");
        }

        public async Task LogErrorAsync(Exception ex, string errorMessage)
        {
            await Console.Error.WriteLineAsync($"[ERROR]: {errorMessage}, [EXCEPTION]: {ex}");
        }

        public async Task LogFatalAsync(string errorMessage)
        {
            await Console.Error.WriteLineAsync($"[FATAL ERROR]: {errorMessage}");
        }

        public async Task LogFatalAsync(Exception ex)
        {
            await Console.Error.WriteLineAsync($"[FATAL ERROR]: {ex.GetErrorMsg()}, [EXCEPTION]: {ex}");
        }

        public async Task LogFatalAsync(Exception ex, string errorMessage)
        {
            await Console.Error.WriteLineAsync($"[FATAL ERROR]: {errorMessage}, [EXCEPTION]: {ex}");
        }
    }
}
