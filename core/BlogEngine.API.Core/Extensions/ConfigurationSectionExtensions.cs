using Microsoft.Extensions.Configuration;

namespace BlogEngine.API.Core.Extensions
{
    public static class ConfigurationSectionExtensions
    {
        public static T Bind<T>(this IConfigurationSection section)
            where T : class, new()
        {
            var t = new T();
            section.Bind(t);
            return t;
        }
    }
}