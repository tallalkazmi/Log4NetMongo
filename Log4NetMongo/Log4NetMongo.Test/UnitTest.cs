using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Log4NetMongo.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod_with_config_values()
        {
            AppLogger logger = new AppLogger();
            logger.LogInfo("Test Info");
            Console.WriteLine("See output for exceptions. Completed successfully");
        }

        [TestMethod]
        public void TestMethod_with_param_values()
        {
            AppLogger logger = new AppLogger(LoggerApplication.MachAuth, LoggerEnvironment.Dev);
            logger.LogInfo("Test Info");
            Console.WriteLine("See output for exceptions. Completed successfully");
        }
    }
}
