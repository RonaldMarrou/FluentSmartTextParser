using FluentSmartTextParser.Interface;
using FluentSmartTextParser.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FluentSmartTextParser.Impl
{
    public class DateTimeSetter : ISetter
    {
        public PropertyType GetPropertyType()
        {
            return PropertyType.DateTime;
        }

        public string GetPropertyTypeName()
        {
            return typeof(DateTime).Name.ToUpper();
        }

        public bool Set<T>(T affectedObject, string propertyName, string value, Dictionary<string, string> custom)
        {
            if(custom == null || !custom.ContainsKey("DateTimeFormat"))
            {
                DateTime temporary;

                if (!DateTime.TryParse(value, out temporary))
                {
                    return false;
                }

                var classProperty = typeof(T).GetProperty(propertyName);

                if (classProperty == null)
                {
                    return false;
                }

                classProperty.SetValue(affectedObject, temporary);

                return true;
            }
            else
            {
                DateTime temporary;

                if (!DateTime.TryParseExact(value, custom["DateTimeFormat"], CultureInfo.InvariantCulture, DateTimeStyles.None, out temporary))
                {
                    return false;
                }

                var classProperty = typeof(T).GetProperty(propertyName);

                if (classProperty == null)
                {
                    return false;
                }

                classProperty.SetValue(affectedObject, temporary);

                return true;
            }            
        }
    }
}
