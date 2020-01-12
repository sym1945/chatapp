using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace chatapp.core
{
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        protected List<ILogger> mLoggers = new List<ILogger>();

        protected object mLoggersLock = new object();

        #endregion

        #region Public Properties

        public LogOutputLevel LogOutputLevel { get; set; }

        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Public Events

        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Constructor

        public BaseLogFactory(ILogger[] loggers = null)
        {
            AddLogger(new DebugLogger());

            if (loggers != null)
                foreach (var logger in loggers)
                    AddLogger(logger);
        }

        #endregion

        #region Public Methods
        public void AddLogger(ILogger logger)
        {
            lock (mLoggersLock)
            {
                if (!mLoggers.Contains(logger))
                    mLoggers.Add(logger);
            }
        }

        public void RemoveLogger(ILogger logger)
        {
            lock (mLoggersLock)
            {
                if (mLoggers.Contains(logger))
                    mLoggers.Remove(logger);
            }
        }

        public void Log(
            string message,
            LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            // If we should not log the message as the level is too low...
            if ((int)level < (int)LogOutputLevel)
                return;

            // If the user wants to know where the log originated from...
            if (IncludeLogOriginDetails)
                message = $"{message} [{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]";

            // Log the list so it is thread-safe
            lock (mLoggersLock)
            {
                // Log to all loggers
                mLoggers.ForEach(logger => logger.Log(message, level));
            }

            // Inform listeners
            NewLog.Invoke((message, level));
        } 

        #endregion

    }
}