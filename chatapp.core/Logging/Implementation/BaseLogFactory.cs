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

        public BaseLogFactory()
        {
            AddLogger(new DebugLogger());
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
            if ((int)level < (int)LogOutputLevel)
                return;

            if (IncludeLogOriginDetails)
                message = $"[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]{Environment.NewLine}{message}";

            mLoggers.ForEach(logger => logger.Log(message, level));

            NewLog.Invoke((message, level));
        } 

        #endregion

    }
}