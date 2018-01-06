using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suucha.WeChat.Core.Utilities
{
    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() =>
          LoggerFactory.CreateLogger<T>();
    }
}
