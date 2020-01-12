using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace chatapp.core
{
    public class TaskManager : ITaskManager
    {
        #region Task Methods
        public async Task Run(Func<Task> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                return await Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }

        public async Task Run(Action action, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                await Task.Run(action);
            }
            catch (Exception ex)
            {
                LogError(ex, origin, filePath, lineNumber);

                throw;
            }
        }
        #endregion

        #region Private Helper Methods

        private void LogError(Exception ex, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            IoC.Logger.Log(
                $"An unexpected error occured running a IoC.Task.Run. {ex.Message}"
                , LogLevel.Debug
                , origin
                , filePath
                , lineNumber);
        }

        #endregion
    }
}