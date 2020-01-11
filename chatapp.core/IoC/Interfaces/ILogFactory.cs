using System;
using System.Runtime.CompilerServices;

namespace chatapp.core
{
    public interface ILogFactory
    {
        #region Events

        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Properties

        LogOutputLevel LogOutputLevel { get; set; }

        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Methods

        void AddLogger(ILogger logger);

        void RemoveLogger(ILogger logger);

        void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        #endregion
    }
}
