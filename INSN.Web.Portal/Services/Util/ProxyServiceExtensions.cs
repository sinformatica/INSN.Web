namespace INSN.Web.Portal.Services.Util
{
    /// <summary>
    /// Proxy Service Extensions
    /// </summary>
    public static class ProxyServiceExtensions
    {
        /// <summary>
        /// Add Proxy
        /// </summary>
        public static void AddProxy<TInterface, TImplementation>(this IServiceCollection services, string httpClientName)
        where TInterface : class
        where TImplementation : class, TInterface
        {
            services.AddScoped<TInterface>(provider =>
            {
                var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(httpClientName);
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>() ?? new HttpContextAccessor();
                return ActivatorUtilities.CreateInstance<TImplementation>(provider, httpClient, httpContextAccessor);
            });
        }
    }
}