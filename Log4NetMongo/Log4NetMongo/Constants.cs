using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetMongo
{

    public static class LoggerApplication
    {
        public const string MachOmega = "MachOmega";
        public const string MachAuth = "MachAuth";
        public const string MachLodging = "MachLodging";
    }

    public static class LoggerEnvironment
    {
        public const string Dev = "Dev";
        public const string Stage = "Stage";
        public const string Prod = "Prod";
        public const string Live = "Live";
    }
}
