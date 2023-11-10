using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private ICacheService _cacheService;
        private string _pattern;

        public CacheRemoveAspect(string pattern)
        {
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
            _pattern = pattern;
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(_pattern);
        }
    }
}
