// TODO: define the 'LogLevel' enum
enum LogLevel {
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0,
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        var logLevel = new Dictionary<string,LogLevel> {
            {"TRC", LogLevel.Trace},
            {"DBG", LogLevel.Debug},
            {"INF", LogLevel.Info},
            {"WRN", LogLevel.Warning},
            {"ERR", LogLevel.Error},
            {"FTL", LogLevel.Fatal}
        };
        if (logLevel.ContainsKey(logLine.Substring(1, 3))) {
            return logLevel[logLine.Substring(1, 3)];
        } else {
            return LogLevel.Unknown;
        } 
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{((int)logLevel)}:{message}";
}
