using System;
using System.Diagnostics;
using System.Reflection;

namespace Log4NetMongo
{
    public class AppLogger : BaseLogger
    {
        log4net.ILog target;

        /// <summary>
        /// Must set ApplicationName and Environment variables in appsettings.
        /// </summary>
        public AppLogger()
        {
            target = GetConfiguredLog();
        }

        public AppLogger(string application, string environment) : base(application, environment)
        {
            target = GetConfiguredLog();
        }

        public void LogDebug(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Debug(message);
        }

        public void LogDebug(string message, Exception exception)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Debug(message, exception);
        }

        public void LogError(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Error(message);
        }

        public void LogError(string message, Exception exception)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Error(message, exception);
        }

        public void LogFatal(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Fatal(message);
        }

        public void LogFatal(string message, Exception exception)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Fatal(message, exception);
        }

        public void LogInfo(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Info(message);
        }

        public void LogInfo(string message, Exception exception)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Info(message, exception);
        }

        public void LogWarning(string message)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Warn(message);
        }

        public void LogWarning(string message, Exception exception)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            target.Warn(message, exception);
        }
    }
}
