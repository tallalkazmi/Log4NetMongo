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

### Log Model
1. Timestamp (System time)
2. Level
3. Thread
4. Application
5. Environment
6. User (Application's user from `ClaimsPrincipal.Current.Identity.Name`)
7. Tenant (User's tenant from `ClaimsPrincipal.Current.FindFirst("tenant")`)
8. Message
9. Data (JSON string of object passed in Data parameter)
10. Exception
11. Method Name (Calling method's name)
12. File Name (Calling log's file name)
13. Line Number (Calling log's line number)
