using System;

namespace chatapp.core
{
    public class FileLogger : ILogger
    {
        #region Public Properties

        public string FilePath { get; set; }

        public bool LogTime { get; set; } = true;

        #endregion

        #region Constructor

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        #endregion

        #region Logger Methods

        public void Log(string message, LogLevel level)
        {
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var timeLogString = LogTime ? $"[{currentTime}] " : "";

            IoC.File.WriteTextToFileAsync($"{timeLogString}{message}{Environment.NewLine}", FilePath, append: true);
        }

        #endregion
    }
}