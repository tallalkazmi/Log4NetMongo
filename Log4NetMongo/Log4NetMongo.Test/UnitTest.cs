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
            logger.LogInfo($"Test Info @ {DateTime.UtcNow}");
            Console.WriteLine("See output for exceptions. Completed successfully");
        }

        [TestMethod]
        public void TestMethod_with_param_values()
        {
            AppLogger logger = new AppLogger("Log4NetMongo",
                "Test",
                "mongodb://appuser:admin#123@CAN-ALPHA:9010/MACH_LOG_TEST?authSource=admin",
                "application.log",
                LogLevel.Error);

            logger.LogError($"Test Error @ {DateTime.UtcNow}");
            Console.WriteLine("See output for exceptions. Completed successfully");
        }

        [TestMethod]
        public void TestMethod_with_data_values()
        {
            AppLogger logger = new AppLogger();
            DataStruct data = new DataStruct()
            {
                Id = 1,
                IsActive = true,
                Message = "Data message"
            };

            logger.LogDebug($"Test Debug @ {DateTime.UtcNow}", data);
            Console.WriteLine("See output for exceptions. Completed successfully");
        }

        public class DataStruct
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
