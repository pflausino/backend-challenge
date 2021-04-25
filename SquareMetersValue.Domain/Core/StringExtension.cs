using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareMetersValue.Domain.Core
{
    public static class StringExtension
    {


        public static string ToQueryString(this List<Guid> guids)
        {
            var guidsDist = guids.Distinct();

            if (!guids.Any())
                return "";

            var baseQuery = "Id in (";

            foreach (var guid in guidsDist)
            {
                baseQuery += $"\'{guid}\',";
            }
            baseQuery = baseQuery.Remove(baseQuery.Length - 1);

            baseQuery += ")";

            return baseQuery;

        }


        public static string ToCamelCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}
