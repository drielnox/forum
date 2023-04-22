using Microsoft.Extensions.Logging;

namespace drielnox.Forum.Presetation.WebForms
{
    internal static class Logging
    {
        public static readonly ILoggerFactory Factory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Trace);
        });

        public static ILogger CreateLogger<T>()
        {
            return Factory.CreateLogger<T>();
        }
    }
}