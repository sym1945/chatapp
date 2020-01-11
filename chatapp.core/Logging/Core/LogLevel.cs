﻿namespace chatapp.core
{
    public enum LogLevel
    {
        /// <summary>
        /// Developper specific information
        /// </summary>
        Debug = 1,
        /// <summary>
        /// Verbose information
        /// </summary>
        Verbose = 2,
        /// <summary>
        /// General information
        /// </summary>
        Informative = 3,
        /// <summary>
        /// An warning
        /// </summary>
        Warning = 4,
        /// <summary>
        /// An error
        /// </summary>
        Error = 5,
        /// <summary>
        /// A success
        /// </summary>
        Success = 6,
    }
}