using Core.CrossCuttingConserns.Caching;
using Core.CrossCuttingConserns.Caching.Microsoft;
using Core.Utilities.IoC_;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheService, InMemoryCacheManager>();
        }
    }
}
