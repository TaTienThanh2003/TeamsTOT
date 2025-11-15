using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using backTOT.Data;
using backTOT.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backTOT.Middleware
{
    public class PermissionCache : IPermissionCache
    {
        private readonly IMemoryCache _cache;
        private readonly IServiceScopeFactory _scopeFactory;
        private const string CacheKey = "Permissions";
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(10);

        public PermissionCache(IMemoryCache cache, IServiceScopeFactory scopeFactory)
        {
            _cache = cache;
            _scopeFactory = scopeFactory;
        }

        public IEnumerable<string> GetAll()
        {
            if (!_cache.TryGetValue(CacheKey, out List<string>? permissions))
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                    permissions = db.Permissions.Select(p => p.Name).ToList();
                    _cache.Set(CacheKey, permissions, CacheDuration);
                }
            }

            return permissions!;
        }

        public void Refresh()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                var permissions = db.Permissions.Select(p => p.Name).ToList();
                _cache.Set(CacheKey, permissions, CacheDuration);
            }
        }
    }
}
