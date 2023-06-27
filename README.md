# Intercom.Extensions.Hosting
Hosting and startup abstractions for Intercom. When using NuGet 3.x this package requires at least version 3.4....

## Usage
> When only supplying bearer token `Intercom.Constants.Url.Production` and `Intercom.Constants.Version.Latest` will be used.
```c#
await Host.CreateDefaultBuilder()
    .UseIntercom((context) => new IntercomConfiguration(context.Configuration.GetValue<string>("Intercom:BearerToken"))
    .Build()
    .RunAsync();
```

```c#
await Host.CreateDefaultBuilder()
    .UseIntercom((context) => new IntercomConfiguration(context.Configuration.GetValue<string>("Intercom:BearerToken"), Intercom.Constants.Url.Production, Intercom.Constants.Version.Latest)
    .Build()
    .RunAsync();
```
