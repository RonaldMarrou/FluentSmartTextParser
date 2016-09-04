using FluentSmartTextParser.Model;
using System;
using System.Collections.Generic;

namespace FluentSmartTextParser.Extension
{
    public static class DotNetType
    {
        private static Dictionary<PropertyType, string> Types { get; set; }


        static DotNetType()
        {
            Types = new Dictionary<PropertyType, string>()
            {
                { PropertyType.Integer, "Int32" },
                { PropertyType.String, "String" },
                { PropertyType.Decimal, "Decimal" }
            };
        }

        public static string GetDotNetType(this PropertyType type)
        {
            return Types[type];
        }

        public static string GetTypeName(this Type type)
        {
            var name = type.Name;

            if(name.StartsWith("Nullable"))
            {
                return Nullable.GetUnderlyingType(type).Name;
            }

            return name;
        }
    }
}
