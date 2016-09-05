using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using System.Collections.Generic;

namespace FluentSmartTextParser.Impl
{
    public class DecimalSetter : ISetter
    {
        public bool Set<T>(T affectedObject, string propertyName, string value, Dictionary<string, string> custom)
        {
            decimal temporary = 0;

            if(!decimal.TryParse(value, out temporary))
            {
                return false;
            }

            var classProperty = typeof(T).GetProperty(propertyName);

            if(classProperty == null)
            {
                return false;
            }

            classProperty.SetValue(affectedObject, temporary);

            return true;
        }

        public PropertyType GetPropertyType()
        {
            return PropertyType.Decimal;
        }

        public string GetPropertyTypeName()
        {
            return typeof(decimal).Name.ToUpper();
        }
    }
}
