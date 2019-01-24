# Log4NetMongo
Project for creating application logs on MongoDb using Log4Net

## Installation
1. Add Log4NetMongo package.
2. Set _MongoLogConnection_ in ConnectionStrings and _MongoLogCollectionName_ in AppSettings
3. Add _ApplicationName_ and _Environment_ values in AppSettings (if you choose to).

## Usage

```csharp
using Log4NetMongo;

AppLogger logger = new AppLogger(LoggerApplication.MachAuth, LoggerEnvironment.Dev);
logger.LogInfo("Test Info");
```

```csharp
using Log4NetMongo;

//Configuration from AppSettings
AppLogger logger = new AppLogger();
logger.LogInfo("Test Info");
```
