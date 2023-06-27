# Intercom.Extensions.Hosting
Hosting and startup abstractions for Intercom. When using NuGet 3.x this package requires at least version 3.4....

## Usage
```c#
await Host.CreateDefaultBuilder()
    .UseIntercom("apiKey")
    .Build()
    .RunAsync();
```


```c#
await Host.CreateDefaultBuilder()
    .UseIntercom((context) => context.Configuration.GetValue<string>("Cronitor:ApiKey"))
    .Build()
    .RunAsync();
```
