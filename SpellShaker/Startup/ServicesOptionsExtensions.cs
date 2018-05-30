using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SpellChecker.Startup
{
    public static class ServicesOptionsExtensions
    {
        /// <summary>
        ///     Configures option of type TConfig with value retrieved from configuration via name of TConfig type
        /// </summary>
        public static void ConfigureOptions<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class
            => services.Configure<TConfig>(configuration.GetSection(typeof(TConfig).Name));
    }
}