# How to use NLog in a .Net Core Console App

## Setup DI
```c#
var services = new ServiceCollection();

//add logging
services.AddLogging();

//build the provider;
var serviceProvider = services.BuildServiceProvider();

```
Source: [AndrewLock.Net](https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/)

## Configure NLog
```c#
var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
loggerFactory.AddNLog();
loggerFactory.ConfigureNLog("nlog.config");
```

## Create a Logger and Log Something
```c#
logger = serviceProvider.GetService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Hello World!");
```