using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using System.Collections.Generic;

namespace FluentSmartTextParser.Impl
{
    public class StringSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value, Dictionary<string, string> custom)
        {
            var classProperty = typeof(T).GetProperty(propertyName);

            if (classProperty == null)
            {
                return false;
            }

            classProperty.SetValue(affectedObject, value);

            return true;
        }

        public PropertyType GetPropertyType()
        {
            return PropertyType.String;
        }

        public string GetPropertyTypeName()
        {
            return typeof(string).Name.ToUpper();
        }
    }
}
