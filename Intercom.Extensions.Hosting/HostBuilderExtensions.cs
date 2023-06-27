using Intercom.Constants;
using Microsoft.Extensions.Hosting;
using System;

namespace Intercom.Extensions.Hosting
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseIntercom(this IHostBuilder builder, string baseUrl, string bearerToken)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            ConfigureIntercom(baseUrl, bearerToken);

            return builder;
        }

        public static IHostBuilder UseIntercom(this IHostBuilder builder, string bearerToken)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            ConfigureIntercom(Url.Production, bearerToken);

            return builder;
        }

        public static IHostBuilder UseCronitor(this IHostBuilder builder, Func<HostBuilderContext, string> options)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.ConfigureServices((context, services) =>
            {
                var apiKey = options(context);
                ConfigureIntercom(apiKey);
            });

            return builder;
        }

        private static void ConfigureIntercom(string baseUrl, string bearerToken)
        {
            if (string.IsNullOrWhiteSpace(bearerToken)) throw new ArgumentNullException(nameof(bearerToken));

            Intercom.Configure(baseUrl, bearerToken);
        }
    }

    public class IntercomOptions
    {
        public string Url { get; set; }
        public string BearerToken { get; set; }

        public IntercomOptions(string url, string bearerToken)
        {
            Url = url;
            BearerToken = bearerToken;
        }
    }
}
