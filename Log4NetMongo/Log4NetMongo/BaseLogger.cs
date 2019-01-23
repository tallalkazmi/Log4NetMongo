using log4net;
using log4net.Config;
using System;
using System.Configuration;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace Log4NetMongo
{
    public abstract class BaseLogger
    {
        private string Username;
        private string TenantId;
        private readonly string Application;
        private readonly string Environment;

        public BaseLogger()
        {
            string _application = ConfigurationManager.AppSettings["ApplicationName"];
            string _environment = ConfigurationManager.AppSettings["Environment"];

            if (string.IsNullOrEmpty(_application))
                throw new ArgumentNullException("ApplicationName", "ApplicationName int appSetting is not set");

            if (string.IsNullOrEmpty(_environment))
                throw new ArgumentNullException("ApplicationName", "ApplicationName int appSetting is not set");

            Application = _application;
            Environment = _environment;
            GlobalContext.Properties.Clear();
            ThreadContext.Properties.Clear();
            SetInstanceVariables(ClaimsPrincipal.Current);
        }

        public BaseLogger(string application, string environment)
        {
            Application = application;
            Environment = environment;
            GlobalContext.Properties.Clear();
            ThreadContext.Properties.Clear();
            SetInstanceVariables(ClaimsPrincipal.Current);
        }

        protected ILog GetConfiguredLog()
        {
            #region ConfigXML
            string xml = @"
<log4net>
	<appender name='MongoDBAppender1' type='Log4Mongo.MongoDBAppender, Log4Mongo'>
		<connectionString value='mongodb://appuser:admin#123@CAN-ALPHA:9010/MACH_LOG?authSource=admin' />
        <collectionName value='application.log' />
        <newCollectionMaxDocs value='100000' />
        <field>
			<name value='timestamp' />
			<layout type='log4net.Layout.RawTimeStampLayout' />
		</field>
		<field>
			<name value='level' />
			<layout type='log4net.Layout.PatternLayout' value='%level' />
		</field>
		<field>
			<name value='thread' />
			<layout type='log4net.Layout.PatternLayout' value='%thread' />
		</field>
		<field>
			<name value='application' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='application' />
			</layout>
		</field>
        <field>
			<name value='environment' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='environment' />
			</layout>
		</field>
        <field>
			<name value='user' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='user' />
			</layout>
		</field>
        <field>
			<name value='tenant' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='tenant' />
			</layout>
		</field>
		<field>
			<name value='message' />
			<layout type='log4net.Layout.PatternLayout' value='%message' />
		</field>
		<field>
			<name value='data' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='data' />
			</layout>
		</field>
		<field>
			<name value='exception' />
			<layout type='log4net.Layout.ExceptionLayout' />
		</field>
		<field>
			<name value='methodName' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='methodName' />
			</layout>
		</field>
		<field>
			<name value='fileName' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='fileName' />
			</layout>
		</field>
        <field>
			<name value='lineNumber' />
			<layout type='log4net.Layout.RawPropertyLayout'>
				<key value='lineNumber' />
			</layout>
		</field>
	</appender>
	<root>
		<level value='ALL' />
		<appender-ref ref='MongoDBAppender1' />
	</root>
</log4net>
";
            #endregion

            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(xml)))
            {
                XmlConfigurator.Configure(stream);
            }

            return LogManager.GetLogger("Logger");
        }

        private void SetInstanceVariables(ClaimsPrincipal principal)
        {
            if (principal == null) return;
            Username = ClaimsPrincipal.Current.Identity.Name;
            Claim tenantClaim = ClaimsPrincipal.Current.FindFirst("tenant");
            TenantId = tenantClaim?.Value;
        }

        protected void SetThreadContextProperties(string methodName, string fileName, string lineNumber)
        {
            ThreadContext.Properties["application"] = Application;
            ThreadContext.Properties["environment"] = Environment;
            ThreadContext.Properties["methodName"] = methodName;
            ThreadContext.Properties["fileName"] = fileName;
            ThreadContext.Properties["lineNumber"] = lineNumber;
            ThreadContext.Properties["user"] = Username;
            ThreadContext.Properties["tenant"] = TenantId;
        }
    }
}
