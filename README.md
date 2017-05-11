# How to use NLog in a .Net Core Console App

## Setup DI
```c#
var services = new ServiceCollection();

//add logging
services.AddLogging();

//build the provider;
var serviceProvider = services.BuildServiceProvider();

```

## Configure NLog
```c#
var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
loggerFactory.AddNLog();
loggerFactory.ConfigureNLog("nlog.config");
```

## Create a Logger adn Log Something
```c#
logger = serviceProvider.GetService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Hello World!");
```