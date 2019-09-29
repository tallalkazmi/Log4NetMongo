using log4net;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Linq;

namespace Log4NetMongo
{
    public class AppLogger : BaseLogger
    {
        readonly ILog target;

        /// <summary>
        /// Initialize Log4Net with optional settings.
        /// </summary>
        /// <param name="application">Application's name. If not provided reads from AppSetting key 'ApplicationName'</param>
        /// <param name="environment">Environment's name. If not provided reads from AppSetting key 'Environment'</param>
        /// <param name="connectionString">MongoDb ConnectionString. If not provided reads from connectionStrings name 'MongoLogConnection'</param>
        /// <param name="collectionName">MongoDb Collection's name. If not provided reads from AppSettings key 'MongoLogCollectionName'</param>
        /// <param name="logLevel">Log4Net log level. Default is set to 'ALL'. If not provided reads from AppSettings key 'LogLevel'</param>
        public AppLogger(string application = null,
            string environment = null,
            string connectionString = null,
            string collectionName = null,
            LogLevel? logLevel = null)
        {
            base.Application = string.IsNullOrWhiteSpace(application) ?
                ConfigurationManager.AppSettings.AllKeys.Any(x => x == "ApplicationName") ?
                ConfigurationManager.AppSettings["ApplicationName"] : throw new SettingsPropertyNotFoundException("Key 'ApplicationName' does not exists.") : application;

            base.Environment = string.IsNullOrWhiteSpace(environment) ?
                ConfigurationManager.AppSettings.AllKeys.Any(x => x == "Environment") ?
                ConfigurationManager.AppSettings["Environment"] : throw new SettingsPropertyNotFoundException("Key 'Environment' does not exists.") : environment;

            base.ConnectionString = string.IsNullOrWhiteSpace(connectionString) ?
                ConfigurationManager.ConnectionStrings["MongoLogConnection"] != null ?
                ConfigurationManager.ConnectionStrings["MongoLogConnection"].ConnectionString : throw new SettingsPropertyNotFoundException("Key 'MongoLogConnection' does not exists.") : connectionString;

            base.Collection = string.IsNullOrWhiteSpace(collectionName) ?
                ConfigurationManager.AppSettings.AllKeys.Any(x => x == "MongoLogCollectionName") ?
                ConfigurationManager.AppSettings["MongoLogCollectionName"] : throw new SettingsPropertyNotFoundException("Key 'MongoLogCollectionName' does not exists.") : collectionName;

            if (ConfigurationManager.AppSettings.AllKeys.Any(x => x == "LogLevel"))
            {
                string _logLevelString = ConfigurationManager.AppSettings["LogLevel"];
                bool isParsed = Enum.TryParse(_logLevelString, out LogLevel _logLevel);
                if (isParsed) LogLevel = _logLevel;
                else throw new InvalidCastException("Key 'LogLevel' is not of an acceptable value. Please set from one of the following: All, Debug, Info, Warn, Error, Fatal, Off");
            }
            base.LogLevel = logLevel;

            target = GetConfiguredLog();
        }

        public void LogDebug(string message, object data = null)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());

            if (data != null)
            {
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string dataJson = oSerializer.Serialize(data);
                ThreadContext.Properties["data"] = dataJson;
            }

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

        public void LogError(string message, object data = null)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            if (data != null)
            {
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string dataJson = oSerializer.Serialize(data);
                ThreadContext.Properties["data"] = dataJson;
            }
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

        public void LogFatal(string message, object data = null)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            if (data != null)
            {
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string dataJson = oSerializer.Serialize(data);
                ThreadContext.Properties["data"] = dataJson;
            }
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

        public void LogInfo(string message, object data = null)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            if (data != null)
            {
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string dataJson = oSerializer.Serialize(data);
                ThreadContext.Properties["data"] = dataJson;
            }
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

        public void LogWarning(string message, object data = null)
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase methodBase = stackFrame.GetMethod();
            SetThreadContextProperties(methodBase.Name, stackFrame.GetFileName(), stackFrame.GetFileLineNumber().ToString());
            if (data != null)
            {
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string dataJson = oSerializer.Serialize(data);
                ThreadContext.Properties["data"] = dataJson;
            }
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
