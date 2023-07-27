using CRUD_Сlients_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD_Сlients_API.Helpers
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value, IJsonConverter converter)
        {
            session.SetString(key, converter.WriteJson<T>(value));
        }
        public static bool Contains(this ISession session, string key)
        {
            return session.Keys.Contains(key);
        }

        public static T Get<T>(this ISession session, string key, IJsonConverter converter)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : converter.ReadJson<T>(value);
        }
    }
}
