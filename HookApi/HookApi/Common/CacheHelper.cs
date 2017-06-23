using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace HookApi.Common
{
    public class CacheHelper
    {
        /// <summary>
        /// 设置缓存    
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expires_in">过期时间秒数</param>
        public static void AddCacheObj(string key, object value, int expires_in)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Add(key, value, null, DateTime.Now.AddSeconds(expires_in), TimeSpan.Zero,
                   CacheItemPriority.Normal, null);
            //Cache.Add("ApiToken", accessToken, null, DateTime.Now.AddSeconds(expires_in), TimeSpan.Zero,
            //    CacheItemPriority.Normal);
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCacheObj(string key)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[key];
        }


        public static T GetCache<T>(string cacheKey) where T : class
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            if (cache[cacheKey] != null)
            {
                return (T)cache[cacheKey];
            }
            return null;
        }
        public static void WriteCache<T>(T value, string cacheKey) where T : class
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(120), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public static void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public static void RemoveCache(string cacheKey)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }
        public static void RemoveCache()
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}