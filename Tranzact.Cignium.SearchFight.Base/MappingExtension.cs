using System.Text.Json;

namespace Tranzact.Cignium.SearchFight.Base
{
    /// <summary>
    /// Extended class for mapping
    /// </summary>
    public static class MappingExtension
    {
        /// <summary>
        /// Map a string object to another class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T MapTo<T>(this string value)
        {

            return JsonSerializer.Deserialize<T>(value,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                }
            );
        }
    }
}
