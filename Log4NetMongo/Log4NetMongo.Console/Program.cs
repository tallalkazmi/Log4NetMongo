using System;

namespace Log4NetMongo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AppLogger logger = new AppLogger("Log4NetMongo",
               "Test",
               "mongodb://appuser:admin#123@CAN-ALPHA:9010/MACH_TEST_LOG_1?authSource=admin",
               "application.log",
               LogLevel.Info);

            //AppLogger logger = new AppLogger();
            logger.LogInfo($"Test Info @ {DateTime.UtcNow}");
        }
    }
}
