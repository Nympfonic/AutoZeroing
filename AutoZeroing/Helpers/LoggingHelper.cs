using EFT.UI;

namespace Arys.AutoZeroing.Helpers
{
    internal static class LoggingHelper
    {
        internal static void LogInfo(string message)
        {
            ConsoleScreen.Log(message);
            Plugin.LogSource.LogInfo(message);
        }

        internal static void LogWarning(string message)
        {
            ConsoleScreen.LogWarning(message);
            Plugin.LogSource.LogWarning(message);
        }

        internal static void LogError(string message)
        {
            ConsoleScreen.LogError(message);
            Plugin.LogSource.LogError(message);
        }
    }
}
