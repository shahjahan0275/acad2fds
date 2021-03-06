﻿namespace Common
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    public class Logger : ILogger
    {
        #region Constants

        private const string FolderName = "Log";

        private const string FileName = "Log.txt";

        private const string LogEntrySeparator = "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _";

        #endregion

        #region Fields

        private readonly string pathToLogFile;
        private readonly string pathToLogFolder;

        private static readonly object syncObj = new object();

        #endregion

        #region Construction and finalization

        public Logger()
        {
            pathToLogFolder = Path.Combine(Info.PluginDirectory, FolderName);
            pathToLogFile = Path.Combine(pathToLogFolder, FileName);
        }

        #endregion

        #region Methods

        public void LogInfo(string info)
        {
            WriteTextToFile(info);
        }

        public void LogError(Exception ex)
        {
            try
            {
                lock (syncObj)
                {
                    var stackTrace = new StackTrace(ex, true);
                    var stackFrame = stackTrace.GetFrame((stackTrace.FrameCount - 1));
                    var fileName = stackFrame.GetFileName();
                    var lineNumber = stackFrame.GetFileLineNumber();
                    var methodBase = stackFrame.GetMethod();

                    var methodName = methodBase.Name;

                    var sb = new StringBuilder();

                    sb.AppendFormat("Error occured: in {0}{1}", fileName, Environment.NewLine);
                    sb.AppendFormat("Method name : {0}{1}", methodName, Environment.NewLine);
                    sb.AppendFormat("Line number : {0}{1}", lineNumber, Environment.NewLine);
                    sb.AppendFormat("Error Message: {0}{1}", ex.Message, Environment.NewLine);

                    if (!string.IsNullOrEmpty(ex.StackTrace))
                        sb.AppendFormat("Stacktrace: {0}{1}{2}", Environment.NewLine, ex.StackTrace, Environment.NewLine);

                    WriteTextToFile(sb.ToString());
                }
            }
            catch (Exception exception)
            {
                WriteTextToFile(ex.Message);
                LogError(exception);
            }
        }

        private void WriteTextToFile(string text)
        {
            lock (syncObj)
            {
                if (!Directory.Exists(FolderName))
                {
                    Directory.CreateDirectory(pathToLogFolder);
                }

                try
                {
                    using (var streamWriter = new StreamWriter(pathToLogFile, true))
                    {

                        streamWriter.WriteLine(LogEntrySeparator);
                        streamWriter.WriteLine(DateTime.UtcNow);
                        streamWriter.WriteLine(text);
                        streamWriter.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }
        }

        #endregion
    }
}
