using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Tranzact.Cignium.SearchFight.Base
{
    public static class MappingExtension
    { 
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
