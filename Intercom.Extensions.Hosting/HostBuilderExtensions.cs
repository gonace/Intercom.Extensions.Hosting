using Intercom.Constants;
using Microsoft.Extensions.Hosting;
using System;
using Version = Intercom.Constants.Version;

namespace Intercom.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        [Obsolete("This method has no more usages and will be removed in a future version, please use ConfigureCronitor(string apiKey) instead.")]
        public static IHostBuilder UseIntercom(this IHostBuilder builder, IntercomConfiguration configuration) =>
            builder.ConfigureIntercom(configuration);

        [Obsolete("This method has no more usages and will be removed in a future version, please use ConfigureCronitor(string apiKey) instead.")]
        public static IHostBuilder UseIntercom(this IHostBuilder builder, Func<HostBuilderContext, IntercomConfiguration> options) =>
            builder.ConfigureIntercom(options);

        public static IHostBuilder ConfigureIntercom(this IHostBuilder builder, IntercomConfiguration configuration)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            ConfigureIntercom(configuration);

            return builder;
        }

        public static IHostBuilder ConfigureIntercom(this IHostBuilder builder, Func<HostBuilderContext, IntercomConfiguration> options)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureServices((context, services) =>
            {
                var configuration = options(context);
                ConfigureIntercom(configuration);
            });

            return builder;
        }

        private static void ConfigureIntercom(IntercomConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            Intercom.Configure(configuration.Url, configuration.BearerToken, configuration.Version);
        }
    }

    public class IntercomConfiguration
    {
        public string BearerToken { get; set; }
        public Url Url { get; set; }
        public Version Version { get; set; }

        public IntercomConfiguration(string bearerToken, Url url, Version version)
        {
            BearerToken = bearerToken;
            Url = url;
            Version = version;
        }

        public IntercomConfiguration(string bearerToken, Url url)
        {
            BearerToken = bearerToken;
            Url = url;
            Version = Version.Latest;
        }

        public IntercomConfiguration(string bearerToken)
        {
            BearerToken = bearerToken;
            Url = Url.Production;
            Version = Version.Latest;

        }
    }
}
