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

        [TestMethod]
        public void TestMethod_with_data_values()
        {
            AppLogger logger = new AppLogger();
            DataStruct data = new DataStruct()
            {
                id = 1,
                IsActive = true,
                message = "Data message"
            };

            logger.LogDebug("Test Debug", data);
            Console.WriteLine("See output for exceptions. Completed successfully");
        }

        public class DataStruct
        {
            public int id { get; set; }
            public string message { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
